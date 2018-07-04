# Unity学习
[TOC]
主要涉及unity中的相关的工具，方法等

## 字体编辑
[参考博客](http://blog.sina.com.cn/s/blog_89d90b7c0102vk20.html)
### 工具
1. [NGUI](https://pan.baidu.com/s/1-cCAYWqj5IeBQZozpUuVLg)
2. [bmfont64.exe](https://pan.baidu.com/s/1Zhf8fsqb2iNT_8vv6X6lZQ): [官网](http://www.angelcode.com/products/bmfont/)
### 要点小计
1. 使用BMFont来生成相关的贴图时，注意贴图本身的高度要一直，不然默认左上对齐会带来不便（例如小数点），此处应该也能动态规避该问题
2. 使用博客中的方式来生成字体文件，需要导入NGUI的包
3. 字体文件生成后，按保存有时不能成功写入具体数据，该问题待查证。
4. 用此方法生成的字体，无法调整字体大小，只能通过缩放倍数的方式实现大小的调节

 