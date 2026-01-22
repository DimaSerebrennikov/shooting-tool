using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Serebrennikov.Tiles.Systems {
    public class Hud {
        HudConfiguration _configuration;
        Data _data;
        public Hud(Data data, HudConfiguration configuration) {
            _data = data;
            _configuration = configuration;
        }
    }
}
