
using System.Diagnostics.Metrics;
using static System.Collections.Specialized.BitVector32;

public class Rootobject
{
    public int count { get; set; }
    public Result[] results { get; set; }
}

public class Result
{
    
   
    public int id { get; set; }

    public string name { get; set; }

    public string description { get; set; }
    public Instruction[] instructions { get; set; }

    public Nutrition nutrition { get; set; }
    
    public string yields { get; set; }
    public object keywords { get; set; }
  
    public int num_servings { get; set; }
    public object total_time_tier { get; set; }
    
    public string thumbnail_url { get; set; }
    public string thumbnail_alt_text { get; set; }
    public object total_time_minutes { get; set; }
    public string original_video_url { get; set; }
    
    public object cook_time_minutes { get; set; }
    public object seo_path { get; set; }
    public object seo_title { get; set; }
    public object prep_time_minutes { get; set; }
    public Section[] sections { get; set; }
}

public class Nutrition
{
    public int carbohydrates { get; set; }
    public int fiber { get; set; }
    public DateTime updated_at { get; set; }
    public int protein { get; set; }
    public int fat { get; set; }
    public int calories { get; set; }
    public int sugar { get; set; }
}

public class Instruction
{
    public int id { get; set; }
    public int position { get; set; }
    public string display_text { get; set; }
    public int start_time { get; set; }
    public object appliance { get; set; }
    public int end_time { get; set; }
}



public class Ingredient
{
    public int id { get; set; }
    public string name { get; set; }
    
}

public class Section
{
    public string name { get; set; }
    public int position { get; set; }
    public Component[] components { get; set; }
    
}
public class Component
{

    public int id { get; set; }
    public int position { get; set; }
    public string raw_text { get; set; }
    public string extra_comment { get; set; }
    public Ingredient ingredient { get; set; }
    
}



