﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates
{
    public class Troll : Enemy
    {
        public float attackRange = 2f;
        public float meleeSpeed = 20f;
        public float meleeDelay = 0.3f;
        public GameObject attackBox;

        private bool isAttacking = false;

        protected override void Update()
        {
            // Call bass update
            base.Update();
            // IF is not attacking AND target is within attackRange
            if (!isAttacking && IsCloseTotarget(attackRange))
            {
                StartCoroutine(Attack());
            }
        }

        IEnumerator Attack()
        {
            // During attack
            isAttacking = true;
            attackBox.SetActive(true);
            behaviourIndex = Behaviour.IDLE;
            yield return new WaitForSeconds(meleeDelay);
            // After attack
            behaviourIndex = Behaviour.SEEK;
            attackBox.SetActive(false);
            isAttacking = false;
        }
    }
}

