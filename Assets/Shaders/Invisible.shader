﻿ Shader "Transparent/CastShadows"
 {
     Subshader
     {
         UsePass "VertexLit/SHADOWCOLLECTOR"    
         UsePass "VertexLit/SHADOWCASTER"
     }
 
     Fallback off
 }