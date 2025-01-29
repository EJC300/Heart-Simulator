using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using TMPro;

//TODO Use a finite state machine to manage states between exercise, stress,rest , and slider
/*
 * Plan:
 * 
 * Heart Attack Simulator with basic digestive simulation 
 * 
 * Create An extensible state machine for the heart states - Done
 * 
 * Create the simple digestive system using a time of day routine thing
 * 
 * Create food types
 * 
 * Create artery health system
 * 
 * Progrss to more advanced simulation model
 * 
 * Refactor as needed
 * 
 */

/*
 * I need to refactor this before I add any of the planned features use an seperate event system and seperate heart controller
 * 
 * Heart Controller - This controls and manages the heartbeat system
 * HeartBeat Manager - Manages the events of the heart sim's heartbeat using a delegates
 * HeartSound
 * Heart Animator
 * Heart Sim UI - Handles UI such as the slider and buttons among other things
 * Heart State Machine - Controls the states but also registers the state to the Heart Sim UI
 * After refactoring follow the same design for the new systems
 * 
 * Placeholder heart disease with full simulated simple digestive proccess
 * 
 * Objectives: 
 * Be prompted to create an individual from age to 21 to 65
 * Use a slider to adjust Activity level, Stress, and Nutrition level 
 * For now display and simulate variables such as Blood Pressure, Blood Viscosity , Arterial Thickness 
 * 
 * 
 * Refine Body to include Metrics such as LDL,HDL, and Triglycerides,and stress
 * 
 * Heart Disease metrics is calculated based on Age, Exercise,Stress, Body Fat,Cholesterol LDL & HDL, and triglycerides
 * 
 * There exists one different variable oxygen
 * 
 * Oxygen is multipied by the recovery rate and targetHeartRate
 * if Oxygen drops below 90 percent for now increase heartrate
 * Oxygen drops to zero at the recoverRate each time the heart beats oxygen increases by a percentage
 * For the placholder heart disease sim ArteryThickness subtracts from oxygen * blood viscosity percentage
 *
 * 
 * 
 */


public class HeartBeatManager : MonoBehaviour
{

    public static Action OnSANodeFire;
    public static Action OnVentriclesContract;
    public static Action OnAVNodeFire;
    public static Action OnValvesClosed;
   
  
}
