# utauPlugin
飴屋／菖蒲氏によって公開されている，Windows向けに作成された歌声合成ソフトウェア「UTAU」の，
プラグイン作成のためのC#(.Net Framework 4.6.1)クラスライブラリです．
visual studioでの使用を想定しています．

UTAU公式サイト(http://utau2008.web.fc2.com/)
UTAUプラグインの仕様(https://www20.atwiki.jp/utaou/pages/64.html)

~~Shift-Jis以外の2バイト文字がヘッダに含まれていると落ちます．~~
多分外国の2バイト環境でも動きます．
本家がutf-8になりそうなので，当面様子見の予定です．

## 導入方法
画像付きチュートリアルはコチラ(https://ch.nicovideo.jp/delta_kimigatame/blomaga/ar1716787)
1. Clone or downloadからzipをダウンロードし，適当な場所に解凍する．
1. [ファイル]-[新規作成]-[プロジェクト]より.Net Frameworkのプロジェクトを作成する．
1. [ファイル]-[追加]-[既存のプロジェクト]より，utauPlugin-master\utauPlugin\utauPlugin.slnを開く．
1. [ソリューションエクスプローラー]-[参照]を右クリックし、[参照の追加]を選ぶ．
1. [プロジェクト]-[ソリューション]よりutauPluginにチェックする．

## 使い方
```Csharp:sample1
using utauPlugin;

namespace sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();
            //
            //具体的な処理
            //
            utauPlugin.Output();
        }
    }
}
```
## 具体的な使用例
UTAU界隈おなじみの半音上げプラグイン(コンソール)の場合
```Csharp:sample2
using utauPlugin;

namespace sample1
{
    class Program
    {
        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();
            foreach(Note note in utauPlugin.note)
            {
                note.SetNoteNum(note.GetNoteNum() + 1);
            }
            utauPlugin.Output();
        }
    }
}
```


## 簡易APIマニュアル
### UtauPlugin(base Ust)
#### UtauPlugin()
#### UtauPlugin(string filePath)
パラメータはUstと同じのため詳細略

#### void Input()
`UtauPlugin.filePath`のファイルをshift_Jisで開き，内容を解析します．

ustのヘッダ情報は`UtauPlugin UtauPlugin`に，ノートの情報は`List UtauPlugin.note`に格納されます．

#### void Output()
`UtauPlugin.filePath`のファイルに編集内容を上書きします．

UTAUプラグインの仕様に則り，書き出し内容は最小限です．

|要素|書出有無|
|:-------|:-------|
|ヘッダ情報|無|
|[PREV][NEXT]|無|
|[#DELETE]|[#DELETE]だけ書き出す(内容は書き出さない)|
|[#INSERT]|すべてのエントリを書き出す|
|その他|変更があったもののみ書き出す|

ただし@つきのパラメータは`readonly`なので書き出しません．

### Ust
#### Ust()
#### Ust(string filePath)
初期化．ファイルパスは宣言時でもあとからSetしても同じです．

#### void SetFilePath(string filePath)
読み書きするファイルを変更できます．

#### string GetFilePath()
filePathはprivate要素なので，こちらのメソッドで情報取得してください．

他のパラメータについても同様にSetとGetができます．

|パラメータ|説明|
|:-------|:-------|
|String FilePath|tempファイルのフルパス|
|float Version|プラグインのバージョン|
|String ProjectName|プロジェクト名|
|String VoiceDir|音源ライブラリのフルパス|
|String CacheDir|キャッシュファイルのフルパス|
|Float Tempo|USTのテンポ|
|String Tool1Path|ツール1(append)のフルパス|
|String Tool2Path|ツール2(resamp)のフルパス|
|String Flags|UST全体のフラグ|
|Boolean Mode2|Mode2使用の有無|
|Boolean utf8|utf8形式かのチェック(現在使用していません)|


### Note
#### Note()
各ノートに必ずある，セクションNo,ノート長,歌詞，音高，先行発声を初期化して持っています．

#### void InitOve(string ove)
#### void InitOve(float ove)
#### void InitOve(int ove)
オーバーラップ値をoveで初期化します．

#### void SetOve(string ove)
#### void SetOve(float ove)
#### void SetOve(int ove)
オーバーラップ値をoveに変更し，`UtauPlugin.Output()`時書き出すようフラグを立てます．

#### Boolean OveIsChanged()
1度でもオーバーラップをSetしていればtrueを，していなければfalseを返します．
初期化されていない場合もfalseを返します．

#### Boolean HasOve()
オーバーラップを初期化していればtrueを，していなければfalseを返します． 以下他のメソッドは初期化していない場合使用できません．

#### float GetOve()
オーバーラップ値を取得します．


他のパラメータも同様にInit,Has,Set,Get,IsChangedが使えます． ただし，セクションNo,ノート長,歌詞，音高，先行発声はノート初期化時に必ずInitされるためHasはありません． テンポ情報は数値計算上の利便性を考慮して，'UtauPlugin.Input()'時に必ずInitされるためHasはありません．

|エントリ名|説明|type|Init|Has|Set|Get|IsChanged|
|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|
|[#0000]|セクションNo.|string|InitNum|-|SetNum|GetNum|-|
|Length=|ノートの長さ|int|InitLength|-|SetLength|GetLength|LengthIsChanged|
|Lyric=|入力された歌詞|string|InitLyric|-|SetLyric|GetLyric|LyricIsChanged|
|Tempo=|テンポ|float|InitTempo|-|SetTempo|GetTempo|TempoIsChanged|
|PreUtterance=|先行発声値|float|InitPre|-|SetPre|GetPre|PreIsChanged|
|VoiceOverlap=|オーバーラップ値|float|InitOve|HasOve|SetOve|GetOve|OveIsChanged|
|StartPoint=|STP値|float|InitStp|HasStp|SetStp|GetStp|StpIsChanged|
|Velocity=|音量|int|InitVelocity|HasVelocity|SetVelocity|GetVelocity|VelocityIsChanged|
|Intensity=|音量|int|InitIntensity|HasIntensity|SetIntensity|GetIntensity|IntensityIsChanged|
|Modulation=|モジュレーション|int|InitMod|HasMod|SetMod|GetMod|ModIsChanged|
|Moduration=|モジュレーション|int|InitMod|HasMod|SetMod|GetMod|ModIsChanged|
|Envelope=|エンベロープ|Envelope|InitEnvelope|HasEnvelope|SetEnvelope|GetEnvelope|EnvelopeIsChanged|
|VBR=|ビブラート|Vibrato|InitVibrato|HasVibrato|SetVibrato|GetVibrato|VibratoIsChanged|
|Flags=|フラグ|string|InitFlags|HasFlags|SetFlags|GetFlags|FlagsIsChanged|
|label=|ラベル|string|InitLabel|HasLabel|SetLabel|GetLabel|LabelIsChanged|
|$region=|選択範囲の始め|string|InitRegion|HasRegion|SetRegion|GetRegion|RegionIsChanged|
|$region_end=|選択範囲の終わり|string|InitRegionEnd|HasRegionEnd|SetRegionEnd|GetRegionEnd|RegionEndIsChanged|

ピッチ(mode1用)

|エントリ名|説明|type|Init|Has|Set|Get|IsChanged|
|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|
|Piches=|mode1用ピッチ数列|List|InitPitches|HasPitches|SetPitches|GetPitches|PitchesIsChanged|
|Pitches=|mode1用ピッチ数列|List|InitPitches|HasPitches|SetPitches|GetPitches|PitchesIsChanged|
|PitchBend=|mode1用ピッチ数列|List|InitPitches|HasPitches|SetPitches|GetPitches|PitchesIsChanged|
|PBStart=|mode1用ピッチ数列の開始位置|float|InitPbStart|HasPbStart|SetPbStart|GetPbStart|PbStartIsChanged|
|PBType=|mode1用ピッチベンドの種類|string|InitPbType|HasPbType|SetPbType|GetPbType|PbTypeIsChanged|

ピッチ(mode2用)
mode2用のピッチのパラメータは内部的には一括で宣言され，各パラメータのInitはプラグインに書き出ししない値の登録のために使用されます．

|エントリ名|説明|type|Init|Has|Set|Get|IsChanged|
|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|
|PBS=|mode2用ピッチの開始位置|string|InitPbs|HasMode2Pitch|SetPbs|GetPbs|PbsIsChanged|
|PBW=|mode2用ポルタメントの間隔|List|InitPbw|HasMode2Pitch|SetPbw|GetPbw|PbwIsChanged|
|PBY=|mode2用ポルタメントの音高|List|InitPby|HasMode2Pitch|SetPby|GetPby|PbyIsChanged|
|PBM=|mode2用ピッチベンドの種類|List|InitPbm|HasMode2Pitch|SetPbm|GetPbm|PbmIsChanged|

読み取り専用のパラメータ

|エントリ名|説明|type|Init|Has|Set|Get|IsChanged|
|:-------|:-------|:-------|:-------|:-------|:-------|:-------|:-------|
|@preuttr=|自動調整後の先行発声値|float|InitAtPre|HasAtPre|SetAtPre|GetAtPre|AtPreIsChanged|
|@overlap=|自動調整後のオーバーラップ値|float|InitAtOve|HasAtOve|SetAtOve|GetAtOve|AtOveIsChanged|
|@stpoint=|自動調整後のstp値|float|InitAtStp|HasAtStp|SetAtStp|GetAtStp|AtStpIsChanged|
|@alias=|自動調整後/prefix.map適用後の歌詞|string|InitAtAlias|HasAtAlias|SetAtAlias|GetAtAlias|AtAliasIsChanged|
|@filename=|使用するwavのvoiceDirからの相対パス|string|InitAtFileName|HasAtFileName|SetAtFileName|GetAtFileName|AtFileNameIsChanged|

その他特殊な操作

|メソッド|説明|
|:-------|:-------|
|Boolean PreHasValue()|先行発声は""で初期化される場合があります．""で初期化している場合trueを返します．|
|string GetNoteNumName()|音高名(C4,C#4,D4...)を返します．|
|string GetKey()|音名(C,C#,D...)を返します．|
|float GetPbsTime()|mode2のピッチ開始の時間を返します．|
|float GetPbsHeight()|mode2のピッチ開始の音高を返します．|
|void SetPbw(int pbw, int point)|'point'個目(0スタート)のPBW値を'pbw'に変更します．|
|void SetPby(int pby, int point)|'point'個目(0スタート)のPBY値を'pby'に変更します．|
|void SetPbm(string pbm, int point)|'point'個目(0スタート)のPBY値を'pbm'に変更します．|
    
### NoteNum
必要な操作は全て`Note`からできるため説明略

### Mode2Pitch
必要な操作は全て`Note`からできるため説明略

### Envelope
`Note`から直接できない操作のみ説明
`Note.envelope`が`Envelope型`なので，'Note.envelope.GetP()'のような使い方を想定しています．

|メソッド|説明|
|:-------|:-------|
|void SetP(float p,int point)|'point'個目(0スタート)のエンベロープのpを変更します．|
|void SetV(int p,int point)|'point'個目(0スタート)のエンベロープのvを変更します．|
|List<float> GetP()|エンベロープのpを取得|
|List<int> GetV()|エンベロープのvを取得|
    

### Vibrato
`Note`から直接できない操作のみ説明
`Note.vibrato`が`Vibrato型`なので，'Note.vibrato.GetLength()'のような使い方を想定しています．
以下の通り各パラメータのSetとGetができます．

|パラメータ|type|Set|Get|説明|
|:-------|:-------|:-------|:-------|:-------|
|Length|float|SetLength|GetLength|ノート長に対するビブラート長|
|Cycle|float|SetCycle|GetCycle|ビブラートの周期|
|Depth|float|SetDepth|GetDepth|ビブラートの深さ|
|FadeInTime|float|SetFadeInTime|GetFadeInTime|ビブラート長に対するフェードインの割合|
|FadeoutTime|float|SetFadeoutTime|GetFadeoutTime|ビブラート長に対するフェードアウトの割合|
|Phase|float|SetPhase|GetPhase|ビブラートの初期位相のずれ|
|Height|float|SetHeight|GetHeight|ビブラートの音程オフセット|


