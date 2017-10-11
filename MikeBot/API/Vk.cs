using VkNet;

namespace MikeBot.API
{
    public static class Vk
    {
        public static VkApi Auth()
        {
            var vk = new VkApi();
            string token = "bfa9879d97d107fad8968a8ec0e521ee1981be66a3f3c82c13976a9a6ebedf7fa18bc7f1d16f40a346b56";
            vk.Authorize(new ApiAuthParams
            {
                AccessToken = token
            });
            return vk;
        }
    }
}
