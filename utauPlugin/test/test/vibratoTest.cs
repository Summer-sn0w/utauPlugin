using Microsoft.VisualStudio.TestTools.UnitTesting;
using utauPlugin;

namespace vibratoTest
{
    [TestClass]
    public class vibratoTest
    {

        //
        //�r�u���[�g�֌W�̃e�X�g
        //

        //�g����1 �r�u���[�g�̊e�p�����[�^���J���}�Ō�������������������ɂ���
        //�錾����D
        //�r�u���[�g�z���
        //1�F�r�u���[�g�̒���(�m�[�g���ɑ΂��銄��)(����)
        //2�F�r�u���[�g�̎���(����)
        //3�F�r�u���[�g�̐[��(cent�P��)(����)
        //4�F�r�u���[�g�̃t�F�[�h�C���̒���(�r�u���[�g�����ɑ΂��銄��)(����)
        //5�F�r�u���[�g�̃t�F�[�h�A�E�g����(�m�[�g���ɑ΂��銄��)(����)
        //6�F�r�u���[�g�̏����ʑ�(����)
        //7�F�r�u���[�g�̏㉺�I�t�Z�b�g(����)
        //    100�ɂ���ƁC�r�u���[�g�̉��[���{���̃m�[�g�̉����ɂȂ�܂��D
        //    -100�ɂ���ƁC�r�u���[�g�̏�[���{���̃m�[�g�̉����ɂȂ�܂��D
        [TestMethod]
        public void SetVbrInit()
        {
            Vibrato vbr = new Vibrato("7,1,2,3.1,4.2,5.3,6.4");
            Assert.IsTrue(7==vbr.GetLength());
            Assert.IsTrue(1 == vbr.GetCycle());
            Assert.IsTrue(2 == vbr.GetDepth());
            Assert.IsTrue(3.1f == vbr.GetFadeInTime());
            Assert.IsTrue(4.2f == vbr.GetFadeOutTime());
            Assert.IsTrue(5.3f == vbr.GetPhase());
            Assert.IsTrue(6.4f == vbr.GetHeight());
            Assert.IsTrue("7,1,2,3.1,4.2,5.3,6.4,0" == vbr.Get());
        }
        //�g����2 ���������Ő錾���CSet�Ńr�u���[�g�̊e�p�����[�^���J���}�Ō��������������n���܂�
        [TestMethod]
        public void SetVbrParam()
        {
            Vibrato vbr = new Vibrato();
            vbr.Set("7,1,2,3.1,4.2,5.3,6.4");
            Assert.IsTrue(7 == vbr.GetLength());
            Assert.IsTrue(1 == vbr.GetCycle());
            Assert.IsTrue(2 == vbr.GetDepth());
            Assert.IsTrue(3.1f == vbr.GetFadeInTime());
            Assert.IsTrue(4.2f == vbr.GetFadeOutTime());
            Assert.IsTrue(5.3f == vbr.GetPhase());
            Assert.IsTrue(6.4f == vbr.GetHeight());
            Assert.IsTrue("7,1,2,3.1,4.2,5.3,6.4,0" == vbr.Get());
        }
        [TestMethod]
        public void SetVbrLengthInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetLength(7);
            Assert.IsTrue(7 == vbr.GetLength());
        }
        [TestMethod]
        public void SetVbrLengthStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetLength("7");
            Assert.IsTrue(7 == vbr.GetLength());
        }
        [TestMethod]
        public void SetVbrCycleInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetCycle(7);
            Assert.IsTrue(7 == vbr.GetCycle());
        }
        [TestMethod]
        public void SetVbrCycleStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetCycle("7");
            Assert.IsTrue(7 == vbr.GetCycle());
        }
        [TestMethod]
        public void SetVbrDepthInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetDepth(7);
            Assert.IsTrue(7 == vbr.GetDepth());
        }
        [TestMethod]
        public void SetVbrDepthStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetDepth("7");
            Assert.IsTrue(7 == vbr.GetDepth());
        }
        [TestMethod]
        public void SetVbrFadeInTimeFloat()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeInTime(7.0f);
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeInTimeInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeInTime(7);
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeInTimeStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeInTime("7");
            Assert.IsTrue(7.0f == vbr.GetFadeInTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeFloat()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeOutTime(7.0f);
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeOutTime(7);
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrFadeOutTimeStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetFadeOutTime("7");
            Assert.IsTrue(7.0f == vbr.GetFadeOutTime());
        }
        [TestMethod]
        public void SetVbrPhaseFloat()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetPhase(7.0f);
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrPhaseInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetPhase(7);
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrPhaseStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetPhase("7");
            Assert.IsTrue(7.0f == vbr.GetPhase());
        }
        [TestMethod]
        public void SetVbrHeightFloat()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetHeight(7.0f);
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
        [TestMethod]
        public void SetVbrHeightInt()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetHeight(7);
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
        [TestMethod]
        public void SetVbrHeightStr()
        {
            Vibrato vbr = new Vibrato();
            vbr.SetHeight("7");
            Assert.IsTrue(7.0f == vbr.GetHeight());
        }
    }
}
