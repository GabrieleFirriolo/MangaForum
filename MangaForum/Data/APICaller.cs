﻿using MangaForum.Models;
using MangaForum.Models.Utilities.Requests;
using MangaForum.Models.Utilities.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MangaForum.Data
{
    public class APICaller
    {
        public static string url = "https://localhost:5001/";

        #region GET
        public static async Task<List<Manga>> GetAllMangas()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + "api/Manga/getallmanga");

                List<Manga> lista = JsonConvert.DeserializeObject<List<Manga>>(result);

                return lista;
            }
            catch
            {
                return null;
            }

        }
        public static async Task<List<ForumTopic>> GetAllTopics()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + "api/Manga/getalltopics");

                List<ForumTopic> lista = JsonConvert.DeserializeObject<List<ForumTopic>>(result);

                return lista;
            }
            catch
            {
                return null;
            }

        }
        public static async Task<Manga> GetMangaById(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Manga/manga/byid={id}");

                Manga response = JsonConvert.DeserializeObject<Manga>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<List<Manga>> GetMangaByName(string name)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Manga/manga/byname={name}");

                List<Manga> response = JsonConvert.DeserializeObject<List<Manga>>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<TopicResponse> GetTopicByName(string name)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Manga/topic/byname={name}");

                TopicResponse response = JsonConvert.DeserializeObject<TopicResponse>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<PostResponse> GetPostById(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Manga/post/byid={id}");

                PostResponse response = JsonConvert.DeserializeObject<PostResponse>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<PostResponse> GetPostOfUser(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Manga/userposts/byid={id}");

                PostResponse response = JsonConvert.DeserializeObject<PostResponse>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<PostResponse> GetPostOfTopic(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Manga/topicposts/byid={id}");

                PostResponse response = JsonConvert.DeserializeObject<PostResponse>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<ReplyResponse> GetRepliesOfUser(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Manga/userreplies/byid={id}");

                ReplyResponse response = JsonConvert.DeserializeObject<ReplyResponse>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<ReplyResponse> GetRepliesOfTopic(int id)
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync(url + $"api/Manga/topicreplies/byid={id}");

                ReplyResponse response = JsonConvert.DeserializeObject<ReplyResponse>(result);

                return response;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        public static async Task<CreatePostResponse> CreatePost(CreatePostRequest request)
        { 
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Manga/CreatePost");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                CreatePostResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<CreatePostResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new CreatePostResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<CreateTopicResponse> CreateTopic(CreateTopicRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Manga/CreateTopic");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                CreateTopicResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<CreateTopicResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new CreateTopicResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<CreateReplyResponse> CreateReply(CreateReplyRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Manga/CreateReply");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                CreateReplyResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<CreateReplyResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new CreateReplyResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        public static async Task<CreateReplyResponse> ModReply(ModReplyRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Manga/ModReply");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                CreateReplyResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<CreateReplyResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new CreateReplyResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<CreateTopicResponse> ModTopic(ModTopicRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "api/Manga/ModTopic");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                CreateTopicResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<CreateTopicResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new CreateTopicResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }

        public static async Task<DeletePostResponse> DeletePost(DeletePostRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + $"api/Manga/DeletePost");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                DeletePostResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<DeletePostResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DeletePostResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<DeleteTopicResponse> DeleteTopic(DeleteTopicRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + $"api/Manga/DeleteTopic");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                DeleteTopicResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<DeleteTopicResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DeleteTopicResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
        public static async Task<DeleteReplyResponse> DeleteReply(DeleteReplyRequest request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + $"api/Manga/DeleteReply");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "DELETE";
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(request);

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                DeleteReplyResponse response;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    response = JsonConvert.DeserializeObject<DeleteReplyResponse>(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                return new DeleteReplyResponse()
                {
                    state = false,
                    Error = new List<string>
                    {
                        ex.Message
                    }
                };
            }
        }
    }
}