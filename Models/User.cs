using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string deactivated { get; set; }
        public int hidden { get; set; }

        public string about { get; set; }
        public string activities { get; set; }
        public string bdate { get; set; }
        public int blacklisted { get; set; }
        public int blacklisted_by_me { get; set; }
        public string books { get; set; }
        public int can_post { get; set; }
        public int can_see_all_posts { get; set; }
        public int can_see_audio { get; set; }
        public int can_send_friend_request { get; set; }
        public int can_write_private_message { get; set; }
        public Career career { get; set; }
        public City city { get; set; }
        public int common_count { get; set; }
        public string connections { get; set; }
        public Contacts contacts { get; set; }
        public Counters counters { get; set; }
        public Country country { get; set; }
        public Crop_photo crop_photo { get; set; }
        public string domain { get; set; }
        public string exports { get; set; }
        public int followers_count { get; set; }
        public int friends_status { get; set; }
        public string games { get; set; }
        public string has_mobile { get; set; }
        public int has_photo { get; set; }
        public string home_town { get; set; }
        public string interests { get; set; }
        public int is_favorite { get; set; }
        public int is_friend { get; set; }
        public int is_hidden_from_feed { get; set; }
        public Last_seen last_seen { get; set; }
        public string lists { get; set; }
        public string maiden_name { get; set; }
        public Military military { get; set; }
        public string movies { get; set; }
        public string music { get; set; }
        public string nickname { get; set; }
        public Occupation occupation { get; set; }
        public int online { get; set; }
        public Personal personal { get; set; }
        public string photo_50 { get; set; }
        public string photo_100 { get; set; }
        public string photo_200_orig { get; set; }
        public string photo_200 { get; set; }
        public string photo_400 { get; set; }
        public string photo_400_orig { get; set; }
        public string photo_max { get; set; }
        public string photo_max_orig { get; set; }
        public string quotes { get; set; }
        public List<Relatives> relatives { get; set; }
        public int relation { get; set; }
        public List<Schools> schools { get; set; }
        public string screen_name { get; set; }
        public int sex { get; set; }
        public string site { get; set; }
        public string status { get; set; }
        public int timezone { get; set; }
        public string tv { get; set; }
        public List<Universities> universities { get; set; }
        public int verified { get; set; }
        public int wall_comments { get; set; }
    }
}
