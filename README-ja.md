# WSOFTConfig( [English](README.md) / Japanese )
![�X�N���[���V���b�g](Screenshot.jpg)
## �T�v
.NET����ȒP�ɗ��p�ł���ݒ�t�@�C��(*.wsconf)��ǂݏ������邽�߂̃��C�u�����ł��B

.NET�̊�{�I�ȃf�[�^�^�ɑΉ����AXML�̂悤�ȊK�w�\���������Ƃ�ڕW�Ƃ��Ă��܂��B

�����̐ݒ�t�@�C���ɑ΂��āA�ȉ��̂悤�ȃA�h�o���e�[�W������܂��B
* �ݒ�t�@�C���̈��k���\
* �ݒ�t�@�C���̃p�X���[�h�ɂ��Í������\
* **�p�X**�ɂ��ړI�̒l���ȒP�ɕ\�����Ƃ��\
* �o�C�i���t�@�C���ŏ����o����邱�Ƃɂ��ȒP�ȓ�ǉ����\
* �ݒ蒆�̒l�ɂ����ł�������t�^���邱�Ƃ��\
* ���@�\�G�f�B�^���������J��
* �ق��̃��C�u�����Ɉˑ������A�قȂ錾��ւ̈ڐA���e��

## �g����
�ݒ�t�@�C����ҏW����ɂ́AWSOFTConfig.UI.Test���g�p���܂��B

C#�ł̊ȒP�Ȏg�������ȉ��Ɏ����܂��B
```csharp
using WSOFT.Config;

namespace WSOFTConfig.Sample
{
    internal static class Program
    {
        public static void Main()
        {
            //�ݒ�t�@�C�������[�J���t�@�C������ǂݍ���
            var config = ConfigFile.FromFile(path);

            //�ݒ�t�@�C���̃��[�g��Sample�Ƃ������O�̒l����������
            config.Write("Sample",value);

            //Sample�Ƃ������O�̒l��ǂݍ���
            config.Read("Sample");

            //Sample�Ƃ������O�̃L�[���擾
            var sample = config.GetConfig("Sample");

            //Sample�̒l��config.Read�̌��ʂƓ���
            sample.Value;

            //�V�����L�[���蓮�Ő���
            var sample2 = new ConfigModel(value2);

            //Sample�̎q�v�f�ɂ���
            sample.Children.Add(sample2);

            //Sample2�̒l���擾
            config.Read("Sample/Sample2");

            //�p�X�̋�؂蕶���͔C�ӂɐݒ�\
            config.Read("Sample\\Sample2",'\\');

            //�ݒ�t�@�C�����Í�������
            config.Password = password;

            //�ݒ�t�@�C�������k����
            config.IsCompressed = true;

            //�ݒ�t�@�C�������[�J���t�@�C���ɏ����o��
            config.SaveAsFile(path);
        }
    }
}

```

## ��������
### �f�[�^�T�C�Y�̐���
MicrosoftCLR�̐����ɂ��A���ꂼ��̒l�ƑS�̂̃t�@�C���̂�����ł��f�[�^�T�C�Y�́A```Int32.MaxValue```�𒴂��邱�Ƃ��ł��܂���B

����ɂ��A���v�ł��悻2GB�ȏ�̃f�[�^��ۑ����邱�Ƃ͂ł��܂���B

### �g�p�ł���f�[�^�^�̎��
WSOFTConfig�͎��̃f�[�^�̓ǂݍ��݂Ə������݂��T�|�[�g���܂��B
|�^�̖��O|�T�v|
:---:|:---
|None|��̒l|
|Boolean|�r�b�g�^|
|Char|�����^|
|String|������^|
|Double|�{���x���������_�^|
|Single|�P���x���������_�^|
|Int16|16�r�b�g�����^|
|UInt16|16�r�b�g���R���^|
|Int32|32�r�b�g�����^|
|UInt32|32�r�b�g���R���^|
|Int64|64�r�b�g�����^|
|UInt64|64�r�b�g���R���^|
|Data|�o�C�i���^|
|DateTime|���t�����^|

## ���C�Z���X
WSOFTConfig is under the [MIT license](LICENCE.md).