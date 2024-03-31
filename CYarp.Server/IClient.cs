﻿using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Yarp.ReverseProxy.Forwarder;

namespace CYarp.Server
{
    /// <summary>
    /// 客户端接口
    /// </summary>
    public interface IClient : IAsyncDisposable
    {
        /// <summary>
        /// 获取唯一标识
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 获取转发的目标Uri
        /// </summary>
        Uri TargetUri { get; }

        /// <summary>
        /// 获取关联的用户信息
        /// </summary>
        ClaimsPrincipal User { get; }

        /// <summary>
        /// 获取传输协议
        /// </summary>
        TransportProtocol Protocol { get; }

        /// <summary>
        /// 获取远程终结点
        /// </summary>
        IPEndPoint? RemoteEndpoint { get; }

        /// <summary>
        /// 获取仍在连接的HttpTunnel数量
        /// </summary>
        int HttpTunnelCount { get; }

        /// <summary>
        /// 获取创建时间
        /// </summary>
        DateTimeOffset CreationTime { get; }

        /// <summary>
        /// 转发http请求
        /// </summary>
        /// <param name="httpContext">http上下文</param>
        /// <param name="requestConfig">转发请求配置</param>
        /// <param name="transformer">http内容转换器</param>
        /// <returns></returns>
        ValueTask<ForwarderError> ForwardHttpAsync(HttpContext httpContext, ForwarderRequestConfig? requestConfig = default, HttpTransformer? transformer = default);
    }
}
