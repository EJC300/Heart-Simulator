using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StateMachine;

//A very basic StateMachine
public class FiniteStateMachine
{
  Stack<State> states = new Stack<State>();

  private State currentState;

 public FiniteStateMachine()
    {
        states.Push(new State());
    }
 public void PushState(State state)
 {
        states.Push(state);
 }


  public void RunState()
    {
        currentState = states.Peek();
        currentState.UpdateState();
    }

  public void FlushState(State state)
    {
        currentState = state;
        currentState.StartState();
        states.Pop().ExitState();
        PushState(currentState);
    }


}
