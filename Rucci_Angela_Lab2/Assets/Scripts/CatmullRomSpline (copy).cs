using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatmullRomSpline : MonoBehaviour {

    // 8x3 array representing the key frames
    private Vector3[] keyFrames = new Vector3[8];
    static readonly float TENSION = 0.5f, SEGMENT_DURATION=0.3f;
    private float completion = 0.0f;
    private int currentIndex = 0;
    bool resetTime = false;
    float startTime;
    float totalTime;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        totalTime = Time.time;
        for (int i = 0; i < 8; i++)
        {
            this.keyFrames[i] = GameObject.Find("Key"+i).transform.position;
        }

        transform.position = this.keyFrames[0];

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        if(resetTime){
            startTime = Time.time;
            resetTime = false;
        }
        completion = Time.time;
        float normalizedCurrentTime = normalizedTime(completion, startTime, (startTime + SEGMENT_DURATION));
        if (normalizedCurrentTime < 1 && currentIndex <7){
            if(currentIndex == 0){
                player.transform.position = getNextPoint(this.keyFrames[currentIndex], this.keyFrames[currentIndex + 1], TENSION *
                                                     (this.keyFrames[currentIndex + 1] - this.keyFrames[currentIndex]), TENSION *
                                                     this.keyFrames[currentIndex + 2] - this.keyFrames[currentIndex + 1]);
            }
            else if (currentIndex<6){
                player.transform.position = getNextPoint(this.keyFrames[currentIndex], this.keyFrames[currentIndex + 1], TENSION *
                                                     (this.keyFrames[currentIndex + 1] - this.keyFrames[currentIndex-1]), TENSION *
                                                     this.keyFrames[currentIndex + 2] - this.keyFrames[currentIndex+1]);
            }
            else{
                player.transform.position = getNextPoint(this.keyFrames[currentIndex], this.keyFrames[currentIndex + 1], TENSION *
                                                     (this.keyFrames[currentIndex + 1] - this.keyFrames[currentIndex]), TENSION *
                                                     this.keyFrames[currentIndex + 1] - this.keyFrames[currentIndex]);
            }

        }else{
            completion = 0;
            currentIndex++;
            resetTime = true;
        }
    }

    private float normalizedTime(float time, float min, float max){
        //return (time - startTime) / SEGMENT_DURATION;
        return (time - min) / (max - min);
    }

    private float easeInAndOut(float time){
        return -2 * (time * time * time) + 3 * (time * time);
    }

    private Vector3 getNextPoint(Vector3 start, Vector3 end, Vector3 tanPoint1, Vector3 tanPoint2)
    {

        float time = normalizedTime(completion, startTime, (startTime + SEGMENT_DURATION));
        //float time = normalizedTime(easeInAndOut(completion), easeInAndOut(startTime), easeInAndOut(startTime + SEGMENT_DURATION));
        //float time = normalizedTime(easeInAndOut(completion-totalTime),0, 7*SEGMENT_DURATION);
        //time = easeInAndOut(completion - startTime);
        return (2.0f * time * time * time - 3.0f * time * time + 1.0f) * start
                + (time * time * time - 2.0f * time * time + time) * tanPoint1
                + (-2.0f * time * time * time + 3.0f * time * time) * end
                + (time * time * time - time * time) * tanPoint2;
    }


}
