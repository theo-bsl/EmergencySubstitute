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
        menu.Play();
    }

    public void StopMenu()
    {
        menu.Stop();
    }

    public void StopAmbiance()
    {
        ambiance.Stop();
    }

    public void Breath()
    {
        actualBreathSrc.Play();
    }

    public void StartNormalBreathing()
    {
        actualBreathSrc = normalBreathSrc;
        timer = breathInterval;
        hardBreathSrc.Stop();
        veryHardBreathSrc.Stop();
        illnessSrc.Stop();
    }

    public void StartHardBreathing()
    {
        actualBreathSrc = hardBreathSrc;
        timer = breathInterval;
        veryHardBreathSrc.Stop();
        illnessSrc.Stop();
        normalBreathSrc.Stop();
    }

    public void StartVeryhardBreathing()
    {
        actualBreathSrc = veryHardBreathSrc;
        timer = breathInterval;
        hardBreathSrc.Stop();
        illnessSrc.Stop();
        normalBreathSrc.Stop();
    }

    public void StopBreathing()
    {
        hardBreathSrc.Stop();
        illnessSrc.Stop();
        normalBreathSrc.Stop();
        normalBreathSrc.Stop();
    }

    public void PlayToussing()
    {
        actualBreathSrc = illnessSrc;
        timer = breathInterval;
    }

    public void MotorBaseSpeed()
    {
        motorSrc.Play();
        slowMotorSrc.Stop();
        fastMotorSrc.Stop();
    }

    public void MotorFastSpeed()
    {
        motorSrc.Stop();
        slowMotorSrc.Stop();
        fastMotorSrc.Play();
    }

    public void MotorSlowSpeed()
    {
        motorSrc.Stop();
        slowMotorSrc.Play();
        fastMotorSrc.Stop();
    }

    public void StopMotor()
    {
        motorSrc.Stop();
        slowMotorSrc.Stop();
        fastMotorSrc.Stop();
    }

    public void StartAcouphene()
    {
        tinnitusSrc.Play();
    }

    public void StopAcouphene()
    {
        tinnitusSrc.Stop();
    }

    public void StartFatalAlarm()
    {
        fatalEventSrc.Play();
    }

    public void StartCrisesAlarm()
    {
        crisesEventSrc.Play();
    }

    public void EndFatalAlarm()
    {
        fatalEventSrc.Stop();
    }

    public void EndCrisesAlarm()
    {
        crisesEventSrc.Stop();
    }

    public void StartHacking()
    {
        hackingSrc.Play();
    }

    public void EndHacking()
    {
        hackingSrc.Stop();
    }

    public void PlayHunger()
    {
        hungerSrc.Play();
    }

    public void PlayEndEvent()
    {
        endEventSrc.Play();
    }

    public void PlayCarlingue()
    {
        bodySrc.Play();
    }

    public void PlayUpBtn()
    {
        upButtonSrc.Play();
    }

    public void PlayDownButton()
    {
        //downButtonSrc.Play();
    }

    public void PlayPopup()
    {
        popupSrc.Play();
    }

    public void PlayWork()
    {
        workSrc.Play();
    }

    public void StartWin()
    {
        victorySrc.Play();
    }

    public void StopWin()
    {
        victorySrc.Stop();
    }

    public void StartLoose()
    {
        defeatSrc.Play();
    }

    public void StopLoose()
    {
        defeatSrc.Stop();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > breathInterval)
        {
            timer = 0;
            Breath();
        }
    }
}
