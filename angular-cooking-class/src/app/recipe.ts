export interface Recipe {
        count: number;
        results: Result[];
      }
export  interface Result {
        id?: number;
        name?: string;
        description?: string;
        instructions: Instruction[];
        nutrition?: Nutrition;
        yields: string;
        keywords: object;
        num_servings: number;
        total_time_tier: object;
        thumbnail_url: string;
        thumbnail_alt_text: string;
        total_time_minutes: object;
        original_video_url: string;
        cook_time_minutes: object;
        seo_path: object;
        seo_title: object;
        prep_time_minutes: object;
        sections: Section[];
      }
export  interface Nutrition {
        carbohydrates: number;
        fiber: number;
        updated_at: Date;
        protein: number;
        fat: number;
        calories: number;
        sugar: number;
      }
export  interface Instruction {
        id: number;
        position: number;
        display_text: string;
        start_time: number;
        appliance: object;
        end_time: number;
      }
export  interface Ingredient {
        id: number;
        name: string;
      }
export  interface Section {
        name: string;
        position: number;
        components: Component[];
      }
export  interface Component {
        id: number;
        position: number;
        raw_text: string;
        extra_comment: string;
        ingredient: Ingredient;
      }

