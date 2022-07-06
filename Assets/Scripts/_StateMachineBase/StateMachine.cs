
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Shizounu.Library.Editor;

namespace Shizounu.AI {
	[RequireComponent(typeof(NavMeshAgent))]
	public class StateMachine : MonoBehaviour {

		[SerializeField] private State startState = null;
		[SerializeField, ReadOnly] private State activeState;
		public State ActiveState {
			get => activeState;
			set {
				if (value == null) 
					throw new ArgumentNullException();
				if (value == activeState) 
					return;
				activeState?.OnExit(this);
				activeState = value;
				activeState?.OnEnter(this);
			}
		}
		[Space]
		public NavMeshAgent navMeshAgent;
		private void Awake()
		{
			navMeshAgent = GetComponent<NavMeshAgent>();
			path = new();
		}

		private void Start() {
			if(startState != null)
				ActiveState = startState;
		}
		public void doTick(){
			ActiveState?.OnUpdate(this);
		}

		[Header("Info")]
		public NavMeshPath path;
	}
}