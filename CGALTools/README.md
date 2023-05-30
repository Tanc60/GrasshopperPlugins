# CGALTools

## CGAL Polygon Offset

A simple but robust offset tool for Simple Polygon using [2D Straight Skeleton and Polygon Offsetting
](https://doc.cgal.org/latest/Straight_skeleton_2/index.html#Chapter_2D_Straight_Skeleton_and_Polygon_Offsetting). Forked from [CGALDotNet](https://github.com/Scrawk/CGALDotNet)

The built in Grasshopper offset tools may be unstable when offsetted lines intersect.

<div align="center">
<table>
	<tr>
		<td><img src="https://github.com/Tanc60/GrasshopperPlugins/blob/main/CGALTools/doc/294469de-505e-47e9-90a3-0bfe19c1cd9b.gif"  width="450"></td>
		<td><img src="https://github.com/Tanc60/GrasshopperPlugins/blob/main/CGALTools/doc/445f7be8-d690-42d4-b2fd-09975c84428a.gif"  width="450"></td>
	</tr>
</table>
  
</div>


This polygon offset tool is robust and can handle multi intersection.
<div align="center">
<table>
	<tr>
		<td><img src="https://github.com/Tanc60/GrasshopperPlugins/blob/main/CGALTools/doc/6889d627-7a40-4eb6-950f-2f8673460401.gif"  width="450"></td>
		<td><img src="https://github.com/Tanc60/GrasshopperPlugins/blob/main/CGALTools/doc/171c4d38-8be4-4ce2-b873-994e41084347.gif"  width="450"></td>
	</tr>
</table>
  
</div>

## Note

For Simple Polygon (A polygon that does not intersect itself and has no holes) ONLY. Curve and open polylines are not supported.

