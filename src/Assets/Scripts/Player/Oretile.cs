﻿using Assets.Scripts.Helpers;
using Motherload.Enums;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Player
{
    public class Oretile : RuleTile
    {
        #region Oretile
        
        private AtlasLoader m_Atlas;

        /// <summary>
        /// Indica se é um minério
        /// </summary>
        private bool IsNormal => TileType == OresTypes.NORMAL;

        /// <summary>
        /// Tipo de piso
        /// </summary>
        public OresTypes TileType { get; set; } = OresTypes.NORMAL;

        /// <summary>
        /// Sobrescreve a informação sobre o piso original
        /// </summary>
        public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
        {
            if(m_Atlas == null)
                m_Atlas = new AtlasLoader("Tileset");
            
            if (!IsNormal)
            {
                tileData.colliderType = Tile.ColliderType.Sprite;
                tileData.sprite = m_Atlas.getAtlas("Tileset_11");
            }
            else
            {
                base.GetTileData(position, tilemap, ref tileData);
            }
        }

        #endregion

    }
}
