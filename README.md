# NeteaseProxyChecker
Very simple WPF Application that checks if a proxy works for Netease Api

To make it work you should paste your proxy with the format: xxx.xxx.xxx.xxx
For example: 111.11.122.7
Other things like typing http, or other stuff will make it fail.

It only makes a GET call to a random API url:  http://yourProxy/music.163.com/api/song/detail?ids=[35847388]
(Adele - Hello is that url ... )
If it returns something it means it worked fine. Otherwise, it failed.

It´s simple and ugly, but it has helped me when i want to find working chinese proxies.

Problem: if you put a proxy that is not from china, I think it will pass, so look for then in specific chinese proxies lists:
http://cn-proxy.com/
