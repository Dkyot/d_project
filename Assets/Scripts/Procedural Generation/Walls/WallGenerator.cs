using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer) {
        HashSet<Vector2Int> basicWallPositions = FindWallsDirections(floorPositions, Direction2D.cardinalDirectionsList);
        HashSet<Vector2Int> cornerWallPositions = FindWallsDirections(floorPositions, Direction2D.diagonalDirectionsList);

        CreateBasicWall(tilemapVisualizer, basicWallPositions, floorPositions);
        CreateCornerWalls(tilemapVisualizer, cornerWallPositions, floorPositions);
    }

    private static void CreateCornerWalls(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> cornerWallPositions, HashSet<Vector2Int> floorPositions) {
        foreach (Vector2Int position in cornerWallPositions){
            string  neighboursBinaryType = "";
            foreach (Vector2Int direction in Direction2D.eightDirectionsList) {
                Vector2Int neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition)) 
                    neighboursBinaryType += "1";
                else
                    neighboursBinaryType += "0";
            }
            tilemapVisualizer.PaintSingleCornerWall(position, neighboursBinaryType);
        }
    }

    private static void CreateBasicWall(TilemapVisualizer tilemapVisualizer, HashSet<Vector2Int> basicWallPositions, HashSet<Vector2Int> floorPositions) {
        foreach (Vector2Int position in basicWallPositions) {
            string  neighboursBinaryType = "";
            foreach (Vector2Int direction in Direction2D.cardinalDirectionsList) {
                Vector2Int neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition)) 
                    neighboursBinaryType += "1";
                else
                    neighboursBinaryType += "0";
            }
            tilemapVisualizer.PaintSingleBasicWall(position, neighboursBinaryType);
        }
    }

    private static HashSet<Vector2Int> FindWallsDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionsList) {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (Vector2Int position in floorPositions) {
            foreach (Vector2Int direction in directionsList) {
                Vector2Int neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition) == false)
                    wallPositions.Add(neighbourPosition);
            }
        }
        return wallPositions;
    }
}