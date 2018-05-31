参考文档: https://en.wikipedia.org/wiki/Sorting_algorithm

各算法对比

<table>
    <tr>
        <td rowspan=2 width=10%>名称</td>
        <td colspan=3 align=center width=30%>时间复杂度</td>
        <td rowspan=2 width=10%>空间复杂度</td>
        <td rowspan=2 width=10%>稳定性</td>
        <td rowspan=2 width=40%>算法概述</td>       
    </tr>
    <tr>
        <td>最好</td>
        <td>平均</td>
        <td>最坏</td>        
    </tr>
    <tr>
    <td>快速排序</td>
    <td bgcolor=lightgreen>nlogn</td>
    <td bgcolor=lightgreen>nlogn</td>
    <td bgcolor=brown>n^2</td>
    <td bgcolor=yellow>logn</td>
    <td bgcolor=yellow>No</td>
    <td>选择第一个数，将剩下的大于它的放右边，小于他的放左边，然后对左右两边执行同样的动作，直到排序完成</td>   
    </tr>
    <tr>
     <td>归并排序</td>
    <td bgcolor=lightgreen>nlogn</td>
    <td bgcolor=lightgreen>nlogn</td>
    <td bgcolor=lightgreen>nlogn</td>
    <td bgcolor=brown>n</td>
    <td bgcolor=lightgreen>yes</td>
    <td>将array等分成2半，对左右两半再等分，直到无法再分，然后将左右两半合并，分别提取第一个字符中的小的值</td>    
    </tr>
    <tr> <td>堆排序</td>
    <td bgcolor=lightgreen>nlogn</td>
    <td bgcolor=lightgreen>nlogn</td>
    <td bgcolor=lightgreen>nlogn</td>
    <td bgcolor=lightgreen>1</td>
    <td bgcolor=brown>no</td>
    <td>排成2叉树，满足根节点比子节点大，然后将最上面的根节点与最后一个元素互换，最后一个元素到顶部后与子节点中大的互换，直到满足堆二叉树</td>    
    </tr>
    <tr> <td>插入排序</td>
    <td bgcolor=lightgreen>n</td>
    <td bgcolor=brown>n^2</td>
    <td bgcolor=brown>n^2</td>
    <td bgcolor=lightgreen>1</td>
    <td bgcolor=lightgreen>yes</td>
    <td>插入一个元素，根前面已插入的元素从后往前比较，如果小则插入</td>    
    </tr>
    <tr> <td>选择排序</td>
    <td bgcolor=brown>n^2</td>
    <td bgcolor=brown>n^2</td>
    <td bgcolor=brown>n^2</td>
    <td bgcolor=lightgreen>1</td>
    <td bgcolor=brown>no</td>
    <td>选择最小的放第一个，选择除第一个最小的放第二个，依次</td>    
    </tr>
</table>
