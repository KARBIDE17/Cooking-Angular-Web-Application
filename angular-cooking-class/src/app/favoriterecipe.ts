export interface Favoriterecipe {
  recipeId: number;
  id?: number;
  name?: string;
  description?: string;
  yields?: string;
  numServings?: number;
  thumbnailUrl?: string;
  thumbnailAltText?: string;
  originalVideoUrl?: string;
  cookTimeMinutes?: number;
  prepTimeMinutes?: number;
  totalTimeMinutes?: number;
  seoPath?: string;
  seoTitle?: string;
  totalTimeTier?: string;
  favoriteId: number;
  userId: number;
  isFavorite?: boolean;
  favoriteDescription?: string;
  instructions: Instruction[];
}
export  interface Instruction {
    id: number;
    position: number;
    display_text: string;
    start_time: number;
    appliance: object;
    end_time: number;
  }