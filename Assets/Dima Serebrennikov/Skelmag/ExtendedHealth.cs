// ExtendedHealth.csC:\GameDev\Halette\Assets\SereDim\Script\Game\Cmd\Health\ExtendedHealth.csExtendedHealth.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class ExtendedHealth {
        IValueMax Health { get; }
        IExtendedHealth _serialization;
        public ExtendedHealth(IValueMax health, IExtendedHealth serialization) {
            Health = health;
            _serialization = serialization;
        }
        public void Start() {
            damageToTick = normalTickDamage;
        }
        public void Update() {
            TickCurrentHealth();
        }
        public void HealExtendedDamage(float healValue) { /*Восстанавливает здоровье, а на остаток уменьшает урон тика.*/
            Health.Value += healValue;
            float missignHealth = Health.Max - Health.Value;
            if (healValue > missignHealth) {
                float rest = healValue - missignHealth;
                damageToTick -= rest;
            }
        }
        public void DealExtendedDamage(float newDamage) {
            damageToTick += newDamage; /*Наносит урон не мгновенно, а со временем, прибавляя значения к экспоненциальному уменьшению здоровья*/
        }
        void TickCurrentHealth() { /*Тикает здоровье каждую дельта времени*/
            Health.Value -= damageToTick * Time.deltaTime;
            damageToTick = TheMath.ExponentDecay(damageToTick, normalTickDamage, decaySpeed, Time.deltaTime);
        }
        float damageToTick { get => _serialization.damageToTick; set => _serialization.damageToTick = value < 0f ? 0f : value; }
        float normalTickDamage { get => _serialization.normalTickDamage; }
        float decaySpeed { get => _serialization.decaySpeed; }
    }
}
