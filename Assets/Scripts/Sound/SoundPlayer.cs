using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer instance;

    public AudioSource motorSrc;
    public AudioSource slowMotorSrc;
    public AudioSource fastMotorSrc;
    public AudioSource destroyedMotorSrc;


    float timer = 5f;
    public float breathInterval;
    private AudioSource actualBreathSrc;

    public AudioSource normalBreathSrc;
    public AudioSource hardBreathSrc;
    public AudioSource veryHardBreathSrc;
    public AudioSource illnessSrc;


    public AudioSource endEventSrc;
    public AudioSource hungerSrc;
    public AudioSource bodySrc;
    public AudioSource upButtonSrc;
    public AudioSource downButtonSrc;
    public AudioSource fatalEventSrc;
    public AudioSource crisesEventSrc;
    public AudioSource tinnitusSrc;
    public AudioSource accelerationSrc;
    public AudioSource hackingSrc;
    public AudioSource popupSrc;
    public AudioSource sighSrc;
    public AudioSource workSrc;

    public AudioSource victorySrc;
    public AudioSource defeatSrc;

    public AudioSource ambiance;
    public AudioSource menu;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        actualBreathSrc = normalBreathSrc;
        MotorBaseSpeed();

    }

    public void StartMenu()
    {
        if(menu == null)
        {
            menu.Play();
        }
    }

    public void StopMenu()
    {
        if (menu == null)
        {
            menu.Stop();
        }
    }

    public void StopAmbiance()
    {
        if(ambiance != null)
        {
            ambiance.Stop();
        }
    }

    public void Breath()
    {
        if(actualBreathSrc != null)
        {
            actualBreathSrc.Play();
        }
    }

    public void StartNormalBreathing()
    {
        if(normalBreathSrc != null)
        {
            actualBreathSrc = normalBreathSrc;
            timer = breathInterval;
            hardBreathSrc.Stop();
            veryHardBreathSrc.Stop();
            illnessSrc.Stop();
        }
    }

    public void StartHardBreathing()
    {
        if (hardBreathSrc != null)
        {
            actualBreathSrc = hardBreathSrc;
            timer = breathInterval;
            veryHardBreathSrc.Stop();
            illnessSrc.Stop();
            normalBreathSrc.Stop();
        }
    }

    public void StartVeryhardBreathing()
    {
        if (veryHardBreathSrc != null)
        {
            actualBreathSrc = veryHardBreathSrc;
            timer = breathInterval;
            hardBreathSrc.Stop();
            illnessSrc.Stop();
            normalBreathSrc.Stop();
        }
    }

    public void StopBreathing()
    {
        if(hardBreathSrc != null)
        {
            hardBreathSrc.Stop();
            illnessSrc.Stop();
            normalBreathSrc.Stop();
            normalBreathSrc.Stop();
        }
    }

    public void PlayToussing()
    {
        actualBreathSrc = illnessSrc;
        timer = breathInterval;
    }

    public void MotorBaseSpeed()
    {
        if(motorSrc != null)
        {
            motorSrc.Play();
            slowMotorSrc.Stop();
            fastMotorSrc.Stop();
        }
    }

    public void MotorFastSpeed()
    {
        if (motorSrc != null)
        {
            motorSrc.Stop();
            slowMotorSrc.Stop();
            fastMotorSrc.Play();
        }
    }

    public void MotorSlowSpeed()
    {
        if (motorSrc != null)
        {
            motorSrc.Stop();
            slowMotorSrc.Play();
            fastMotorSrc.Stop();
        }
    }

    public void StopMotor()
    {
        if (motorSrc != null)
        {
            motorSrc.Stop();
            slowMotorSrc.Stop();
            fastMotorSrc.Stop();
        }
    }

    public void StartAcouphene()
    {
        if (tinnitusSrc != null)
        {
            tinnitusSrc.Play();
        }
    }

    public void StopAcouphene()
    {
        if(tinnitusSrc != null)
        {
            tinnitusSrc.Stop();
        }
    }

    public void StartFatalAlarm()
    {
        if (fatalEventSrc != null)
        {
            fatalEventSrc.Play();
        }
    }

    public void StartCrisesAlarm()
    {
        if (crisesEventSrc != null)
        {
            crisesEventSrc.Play();
        }
    }

    public void EndFatalAlarm()
    {
        if(fatalEventSrc != null)
        {
            fatalEventSrc.Stop();
        }
    }

    public void EndCrisesAlarm()
    {
        if(crisesEventSrc != null)
        {
            crisesEventSrc.Stop();
        }
    }

    public void StartHacking()
    {
        if (hackingSrc != null)
        {
            hackingSrc.Play();
        }
    }

    public void EndHacking()
    {
        if(hackingSrc != null)
        {
            hackingSrc.Stop();
        }
    }

    public void PlayHunger()
    {
        if(hungerSrc != null)
        {
            hungerSrc.Play();
        }
    }

    public void PlayEndEvent()
    {
        if(endEventSrc != null)
        {
            endEventSrc.Play();
        }
    }

    public void PlayCarlingue()
    {
        if(bodySrc != null)
        {
            bodySrc.Play();
        }
    }

    public void PlayUpBtn()
    {
        if(upButtonSrc != null)
        {
            upButtonSrc.Play();
        }
    }

    public void PlayDownButton()
    {
        if(downButtonSrc != null)
        {
            //downButtonSrc.Play();
        }
    }

    public void PlayPopup()
    {
        if(popupSrc != null)
        {
            popupSrc.Play();
        }
    }

    public void PlayWork()
    {
        if(workSrc != null)
        {
            workSrc.Play();
        }
    }

    public void StartWin()
    {
        if (victorySrc != null)
        {
            victorySrc.Play();
        }
    }

    public void StopWin()
    {
        if(victorySrc != null)
        {
            victorySrc.Stop();
        }
    }

    public void StartLoose()
    {
        if (defeatSrc != null)
        {
            defeatSrc.Play();
        }
    }

    public void StopLoose()
    {
        if(defeatSrc != null)
        {
            defeatSrc.Stop();
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > breathInterval && normalBreathSrc != null)
        {
            timer = 0;
            Breath();
        }
    }
}
