using Newtonsoft.Json;

namespace Domains
{
    public class CanvasConfig
    {
        [JsonProperty("height")]
        public int? Height;

        [JsonProperty("ratio")]
        public string Ratio;

        [JsonProperty("width")]
        public int? Width;
    }

    public class Canvase
    {
        [JsonProperty("album_image")]
        public string AlbumImage;

        [JsonProperty("blur")]
        public double? Blur;

        [JsonProperty("color")]
        public string Color;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("image")]
        public string Image;

        [JsonProperty("image_id")]
        public string ImageId;

        [JsonProperty("image_name")]
        public string ImageName;

        [JsonProperty("source_platform")]
        public int? SourcePlatform;

        [JsonProperty("team_id")]
        public string TeamId;

        [JsonProperty("type")]
        public string Type;
    }

    public class CaptionTemplateInfo
    {
        [JsonProperty("category_id")]
        public string CategoryId;

        [JsonProperty("category_name")]
        public string CategoryName;

        [JsonProperty("effect_id")]
        public string EffectId;

        [JsonProperty("is_new")]
        public bool? IsNew;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("request_id")]
        public string RequestId;

        [JsonProperty("resource_id")]
        public string ResourceId;

        [JsonProperty("resource_name")]
        public string ResourceName;

        [JsonProperty("source_platform")]
        public int? SourcePlatform;
    }

    public class Clip
    {
        [JsonProperty("alpha")]
        public double? Alpha;

        [JsonProperty("flip")]
        public Flip Flip;

        [JsonProperty("rotation")]
        public double? Rotation;

        [JsonProperty("scale")]
        public Scale Scale;

        [JsonProperty("transform")]
        public Transform Transform;
    }

    public class ComboInfo
    {
        [JsonProperty("text_templates")]
        public List<object> TextTemplates;
    }

    public class Config
    {
        [JsonProperty("adjust_max_index")]
        public int? AdjustMaxIndex;

        [JsonProperty("attachment_info")]
        public List<object> AttachmentInfo;

        [JsonProperty("combination_max_index")]
        public int? CombinationMaxIndex;

        [JsonProperty("export_range")]
        public object ExportRange;

        [JsonProperty("extract_audio_last_index")]
        public int? ExtractAudioLastIndex;

        [JsonProperty("lyrics_recognition_id")]
        public string LyricsRecognitionId;

        [JsonProperty("lyrics_sync")]
        public bool? LyricsSync;

        [JsonProperty("lyrics_taskinfo")]
        public List<LyricsTaskinfo> LyricsTaskinfo;

        [JsonProperty("maintrack_adsorb")]
        public bool? MaintrackAdsorb;

        [JsonProperty("material_save_mode")]
        public int? MaterialSaveMode;

        [JsonProperty("multi_language_current")]
        public string MultiLanguageCurrent;

        [JsonProperty("multi_language_list")]
        public List<object> MultiLanguageList;

        [JsonProperty("multi_language_main")]
        public string MultiLanguageMain;

        [JsonProperty("multi_language_mode")]
        public string MultiLanguageMode;

        [JsonProperty("original_sound_last_index")]
        public int? OriginalSoundLastIndex;

        [JsonProperty("record_audio_last_index")]
        public int? RecordAudioLastIndex;

        [JsonProperty("sticker_max_index")]
        public int? StickerMaxIndex;

        [JsonProperty("subtitle_keywords_config")]
        public object SubtitleKeywordsConfig;

        [JsonProperty("subtitle_recognition_id")]
        public string SubtitleRecognitionId;

        [JsonProperty("subtitle_sync")]
        public bool? SubtitleSync;

        [JsonProperty("subtitle_taskinfo")]
        public List<SubtitleTaskinfo> SubtitleTaskinfo;

        [JsonProperty("system_font_list")]
        public List<object> SystemFontList;

        [JsonProperty("video_mute")]
        public bool? VideoMute;

        [JsonProperty("zoom_info_params")]
        public object ZoomInfoParams;
    }

    public class Crop
    {
        [JsonProperty("lower_left_x")]
        public double? LowerLeftX;

        [JsonProperty("lower_left_y")]
        public double? LowerLeftY;

        [JsonProperty("lower_right_x")]
        public double? LowerRightX;

        [JsonProperty("lower_right_y")]
        public double? LowerRightY;

        [JsonProperty("upper_left_x")]
        public double? UpperLeftX;

        [JsonProperty("upper_left_y")]
        public double? UpperLeftY;

        [JsonProperty("upper_right_x")]
        public double? UpperRightX;

        [JsonProperty("upper_right_y")]
        public double? UpperRightY;
    }

    public class Flip
    {
        [JsonProperty("horizontal")]
        public bool? Horizontal;

        [JsonProperty("vertical")]
        public bool? Vertical;
    }

    public class HdrSettings
    {
        [JsonProperty("intensity")]
        public double? Intensity;

        [JsonProperty("mode")]
        public int? Mode;

        [JsonProperty("nits")]
        public int? Nits;
    }

    public class Keyframes
    {
        [JsonProperty("adjusts")]
        public List<object> Adjusts;

        [JsonProperty("audios")]
        public List<object> Audios;

        [JsonProperty("effects")]
        public List<object> Effects;

        [JsonProperty("filters")]
        public List<object> Filters;

        [JsonProperty("handwrites")]
        public List<object> Handwrites;

        [JsonProperty("stickers")]
        public List<object> Stickers;

        [JsonProperty("texts")]
        public List<object> Texts;

        [JsonProperty("videos")]
        public List<object> Videos;
    }

    public class LastModifiedPlatform
    {
        [JsonProperty("app_id")]
        public int? AppId;

        [JsonProperty("app_source")]
        public string AppSource;

        [JsonProperty("app_version")]
        public string AppVersion;

        [JsonProperty("device_id")]
        public string DeviceId;

        [JsonProperty("hard_disk_id")]
        public string HardDiskId;

        [JsonProperty("mac_address")]
        public string MacAddress;

        [JsonProperty("os")]
        public string Os;

        [JsonProperty("os_version")]
        public string OsVersion;
    }

    public class LyricsTaskinfo
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("language")]
        public string Language;

        [JsonProperty("remove_invalid_task_id")]
        public string RemoveInvalidTaskId;

        [JsonProperty("type")]
        public int? Type;
    }

    public class MaterialAnimation
    {
        [JsonProperty("animations")]
        public List<object> Animations;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("multi_language_current")]
        public string MultiLanguageCurrent;

        [JsonProperty("type")]
        public string Type;
    }

    public class Materials
    {
        [JsonProperty("ai_translates")]
        public List<object> AiTranslates;

        [JsonProperty("audio_balances")]
        public List<object> AudioBalances;

        [JsonProperty("audio_effects")]
        public List<object> AudioEffects;

        [JsonProperty("audio_fades")]
        public List<object> AudioFades;

        [JsonProperty("audio_track_indexes")]
        public List<object> AudioTrackIndexes;

        [JsonProperty("audios")]
        public List<object> Audios;

        [JsonProperty("beats")]
        public List<object> Beats;

        [JsonProperty("canvases")]
        public List<Canvase> Canvases;

        [JsonProperty("chromas")]
        public List<object> Chromas;

        [JsonProperty("color_curves")]
        public List<object> ColorCurves;

        [JsonProperty("digital_humans")]
        public List<object> DigitalHumans;

        [JsonProperty("drafts")]
        public List<object> Drafts;

        [JsonProperty("effects")]
        public List<object> Effects;

        [JsonProperty("flowers")]
        public List<object> Flowers;

        [JsonProperty("green_screens")]
        public List<object> GreenScreens;

        [JsonProperty("handwrites")]
        public List<object> Handwrites;

        [JsonProperty("hsl")]
        public List<object> Hsl;

        [JsonProperty("images")]
        public List<object> Images;

        [JsonProperty("log_color_wheels")]
        public List<object> LogColorWheels;

        [JsonProperty("loudnesses")]
        public List<object> Loudnesses;

        [JsonProperty("manual_deformations")]
        public List<object> ManualDeformations;

        [JsonProperty("masks")]
        public List<object> Masks;

        [JsonProperty("material_animations")]
        public List<MaterialAnimation> MaterialAnimations;

        [JsonProperty("material_colors")]
        public List<object> MaterialColors;

        [JsonProperty("multi_language_refs")]
        public List<object> MultiLanguageRefs;

        [JsonProperty("placeholders")]
        public List<object> Placeholders;

        [JsonProperty("plugin_effects")]
        public List<object> PluginEffects;

        [JsonProperty("primary_color_wheels")]
        public List<object> PrimaryColorWheels;

        [JsonProperty("realtime_denoises")]
        public List<object> RealtimeDenoises;

        [JsonProperty("shapes")]
        public List<object> Shapes;

        [JsonProperty("smart_crops")]
        public List<object> SmartCrops;

        [JsonProperty("smart_relights")]
        public List<object> SmartRelights;

        [JsonProperty("sound_channel_mappings")]
        public List<SoundChannelMapping> SoundChannelMappings;

        [JsonProperty("speeds")]
        public List<Speed> Speeds;

        [JsonProperty("stickers")]
        public List<object> Stickers;

        [JsonProperty("tail_leaders")]
        public List<object> TailLeaders;

        [JsonProperty("text_templates")]
        public List<object> TextTemplates;

        [JsonProperty("texts")]
        public List<Text> Texts;

        [JsonProperty("time_marks")]
        public List<object> TimeMarks;

        [JsonProperty("transitions")]
        public List<object> Transitions;

        [JsonProperty("video_effects")]
        public List<object> VideoEffects;

        [JsonProperty("video_trackings")]
        public List<object> VideoTrackings;

        [JsonProperty("videos")]
        public List<Video> Videos;

        [JsonProperty("vocal_beautifys")]
        public List<object> VocalBeautifys;

        [JsonProperty("vocal_separations")]
        public List<VocalSeparation> VocalSeparations;
    }

    public class Matting
    {
        [JsonProperty("flag")]
        public int? Flag;

        [JsonProperty("has_use_quick_brush")]
        public bool? HasUseQuickBrush;

        [JsonProperty("has_use_quick_eraser")]
        public bool? HasUseQuickEraser;

        [JsonProperty("interactiveTime")]
        public List<object> InteractiveTime;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("strokes")]
        public List<object> Strokes;
    }

    public class Platform
    {
        [JsonProperty("app_id")]
        public int? AppId;

        [JsonProperty("app_source")]
        public string AppSource;

        [JsonProperty("app_version")]
        public string AppVersion;

        [JsonProperty("device_id")]
        public string DeviceId;

        [JsonProperty("hard_disk_id")]
        public string HardDiskId;

        [JsonProperty("mac_address")]
        public string MacAddress;

        [JsonProperty("os")]
        public string Os;

        [JsonProperty("os_version")]
        public string OsVersion;
    }

    public class ResponsiveLayout
    {
        [JsonProperty("enable")]
        public bool? Enable;

        [JsonProperty("horizontal_pos_layout")]
        public int? HorizontalPosLayout;

        [JsonProperty("size_layout")]
        public int? SizeLayout;

        [JsonProperty("target_follow")]
        public string TargetFollow;

        [JsonProperty("vertical_pos_layout")]
        public int? VerticalPosLayout;
    }

    public class DraftContent
    {
        [JsonProperty("canvas_config")]
        public CanvasConfig CanvasConfig;

        [JsonProperty("color_space")]
        public int? ColorSpace;

        [JsonProperty("config")]
        public Config Config;

        [JsonProperty("cover")]
        public object Cover;

        [JsonProperty("create_time")]
        public int? CreateTime;

        [JsonProperty("duration")]
        public int? Duration;

        [JsonProperty("extra_info")]
        public object ExtraInfo;

        [JsonProperty("fps")]
        public double? Fps;

        [JsonProperty("free_render_index_mode_on")]
        public bool? FreeRenderIndexModeOn;

        [JsonProperty("group_container")]
        public object GroupContainer;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("keyframe_graph_list")]
        public List<object> KeyframeGraphList;

        [JsonProperty("keyframes")]
        public Keyframes Keyframes;

        [JsonProperty("last_modified_platform")]
        public LastModifiedPlatform LastModifiedPlatform;

        [JsonProperty("materials")]
        public Materials Materials;

        [JsonProperty("mutable_config")]
        public object MutableConfig;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("new_version")]
        public string NewVersion;

        [JsonProperty("platform")]
        public Platform Platform;

        [JsonProperty("relationships")]
        public List<object> Relationships;

        [JsonProperty("render_index_track_mode_on")]
        public bool? RenderIndexTrackModeOn;

        [JsonProperty("retouch_cover")]
        public object RetouchCover;

        [JsonProperty("source")]
        public string Source;

        [JsonProperty("static_cover_image_path")]
        public string StaticCoverImagePath;

        [JsonProperty("time_marks")]
        public object TimeMarks;

        [JsonProperty("tracks")]
        public List<Track> Tracks;

        [JsonProperty("update_time")]
        public int? UpdateTime;

        [JsonProperty("version")]
        public int? Version;
    }

    public class Scale
    {
        [JsonProperty("x")]
        public double? X;

        [JsonProperty("y")]
        public double? Y;
    }

    public class Segment
    {
        [JsonProperty("caption_info")]
        public object CaptionInfo;

        [JsonProperty("cartoon")]
        public bool? Cartoon;

        [JsonProperty("clip")]
        public Clip Clip;

        [JsonProperty("common_keyframes")]
        public List<object> CommonKeyframes;

        [JsonProperty("enable_adjust")]
        public bool? EnableAdjust;

        [JsonProperty("enable_color_curves")]
        public bool? EnableColorCurves;

        [JsonProperty("enable_color_match_adjust")]
        public bool? EnableColorMatchAdjust;

        [JsonProperty("enable_color_wheels")]
        public bool? EnableColorWheels;

        [JsonProperty("enable_lut")]
        public bool? EnableLut;

        [JsonProperty("enable_smart_color_adjust")]
        public bool? EnableSmartColorAdjust;

        [JsonProperty("extra_material_refs")]
        public List<string> ExtraMaterialRefs;

        [JsonProperty("group_id")]
        public string GroupId;

        [JsonProperty("hdr_settings")]
        public HdrSettings HdrSettings;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("intensifies_audio")]
        public bool? IntensifiesAudio;

        [JsonProperty("is_placeholder")]
        public bool? IsPlaceholder;

        [JsonProperty("is_tone_modify")]
        public bool? IsToneModify;

        [JsonProperty("keyframe_refs")]
        public List<object> KeyframeRefs;

        [JsonProperty("last_nonzero_volume")]
        public double? LastNonzeroVolume;

        [JsonProperty("material_id")]
        public string MaterialId;

        [JsonProperty("render_index")]
        public int? RenderIndex;

        [JsonProperty("responsive_layout")]
        public ResponsiveLayout ResponsiveLayout;

        [JsonProperty("reverse")]
        public bool? Reverse;

        [JsonProperty("source_timerange")]
        public SourceTimerange SourceTimerange;

        [JsonProperty("speed")]
        public double? Speed;

        [JsonProperty("target_timerange")]
        public TargetTimerange TargetTimerange;

        [JsonProperty("template_id")]
        public string TemplateId;

        [JsonProperty("template_scene")]
        public string TemplateScene;

        [JsonProperty("track_attribute")]
        public int? TrackAttribute;

        [JsonProperty("track_render_index")]
        public int? TrackRenderIndex;

        [JsonProperty("uniform_scale")]
        public UniformScale UniformScale;

        [JsonProperty("visible")]
        public bool? Visible;

        [JsonProperty("volume")]
        public double? Volume;
    }

    public class ShadowPoint
    {
        [JsonProperty("x")]
        public double? X;

        [JsonProperty("y")]
        public double? Y;
    }

    public class SoundChannelMapping
    {
        [JsonProperty("audio_channel_mapping")]
        public int? AudioChannelMapping;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("is_config_open")]
        public bool? IsConfigOpen;

        [JsonProperty("type")]
        public string Type;
    }

    public class SourceTimerange
    {
        [JsonProperty("duration")]
        public int? Duration;

        [JsonProperty("start")]
        public int? Start;
    }

    public class Speed
    {
        [JsonProperty("curve_speed")]
        public object CurveSpeed;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("mode")]
        public int? Mode;

        [JsonProperty("speed")]
        public double? _Speed;

        [JsonProperty("type")]
        public string Type;
    }

    public class Stable
    {
        [JsonProperty("matrix_path")]
        public string MatrixPath;

        [JsonProperty("stable_level")]
        public int? StableLevel;

        [JsonProperty("time_range")]
        public TimeRange TimeRange;
    }

    public class SubtitleTaskinfo
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("language")]
        public string Language;

        [JsonProperty("remove_invalid_task_id")]
        public string RemoveInvalidTaskId;

        [JsonProperty("type")]
        public int? Type;
    }

    public class TargetTimerange
    {
        [JsonProperty("duration")]
        public long Duration;

        [JsonProperty("start")]
        public long Start;
    }

    public class Text
    {
        [JsonProperty("add_type")]
        public int? AddType;

        [JsonProperty("alignment")]
        public int? Alignment;

        [JsonProperty("background_alpha")]
        public double? BackgroundAlpha;

        [JsonProperty("background_color")]
        public string BackgroundColor;

        [JsonProperty("background_height")]
        public double? BackgroundHeight;

        [JsonProperty("background_horizontal_offset")]
        public double? BackgroundHorizontalOffset;

        [JsonProperty("background_round_radius")]
        public double? BackgroundRoundRadius;

        [JsonProperty("background_style")]
        public int? BackgroundStyle;

        [JsonProperty("background_vertical_offset")]
        public double? BackgroundVerticalOffset;

        [JsonProperty("background_width")]
        public double? BackgroundWidth;

        [JsonProperty("base_content")]
        public string BaseContent;

        [JsonProperty("bold_width")]
        public double? BoldWidth;

        [JsonProperty("border_alpha")]
        public double? BorderAlpha;

        [JsonProperty("border_color")]
        public string BorderColor;

        [JsonProperty("border_width")]
        public double? BorderWidth;

        [JsonProperty("caption_template_info")]
        public CaptionTemplateInfo CaptionTemplateInfo;

        [JsonProperty("check_flag")]
        public int? CheckFlag;

        [JsonProperty("combo_info")]
        public ComboInfo ComboInfo;

        [JsonProperty("content")]
        public string Content;

        [JsonProperty("fixed_height")]
        public double? FixedHeight;

        [JsonProperty("fixed_width")]
        public double? FixedWidth;

        [JsonProperty("font_category_id")]
        public string FontCategoryId;

        [JsonProperty("font_category_name")]
        public string FontCategoryName;

        [JsonProperty("font_id")]
        public string FontId;

        [JsonProperty("font_name")]
        public string FontName;

        [JsonProperty("font_path")]
        public string FontPath;

        [JsonProperty("font_resource_id")]
        public string FontResourceId;

        [JsonProperty("font_size")]
        public double? FontSize;

        [JsonProperty("font_source_platform")]
        public int? FontSourcePlatform;

        [JsonProperty("font_team_id")]
        public string FontTeamId;

        [JsonProperty("font_title")]
        public string FontTitle;

        [JsonProperty("font_url")]
        public string FontUrl;

        [JsonProperty("fonts")]
        public List<object> Fonts;

        [JsonProperty("force_apply_line_max_width")]
        public bool? ForceApplyLineMaxWidth;

        [JsonProperty("global_alpha")]
        public double? GlobalAlpha;

        [JsonProperty("group_id")]
        public string GroupId;

        [JsonProperty("has_shadow")]
        public bool? HasShadow;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("initial_scale")]
        public double? InitialScale;

        [JsonProperty("inner_padding")]
        public double? InnerPadding;

        [JsonProperty("is_rich_text")]
        public bool? IsRichText;

        [JsonProperty("italic_degree")]
        public int? ItalicDegree;

        [JsonProperty("ktv_color")]
        public string KtvColor;

        [JsonProperty("language")]
        public string Language;

        [JsonProperty("layer_weight")]
        public int? LayerWeight;

        [JsonProperty("letter_spacing")]
        public double? LetterSpacing;

        [JsonProperty("line_feed")]
        public int? LineFeed;

        [JsonProperty("line_max_width")]
        public double? LineMaxWidth;

        [JsonProperty("line_spacing")]
        public double? LineSpacing;

        [JsonProperty("multi_language_current")]
        public string MultiLanguageCurrent;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("original_size")]
        public List<object> OriginalSize;

        [JsonProperty("preset_category")]
        public string PresetCategory;

        [JsonProperty("preset_category_id")]
        public string PresetCategoryId;

        [JsonProperty("preset_has_set_alignment")]
        public bool? PresetHasSetAlignment;

        [JsonProperty("preset_id")]
        public string PresetId;

        [JsonProperty("preset_index")]
        public int? PresetIndex;

        [JsonProperty("preset_name")]
        public string PresetName;

        [JsonProperty("recognize_task_id")]
        public string RecognizeTaskId;

        [JsonProperty("recognize_type")]
        public int? RecognizeType;

        [JsonProperty("relevance_segment")]
        public List<object> RelevanceSegment;

        [JsonProperty("shadow_alpha")]
        public double? ShadowAlpha;

        [JsonProperty("shadow_angle")]
        public double? ShadowAngle;

        [JsonProperty("shadow_color")]
        public string ShadowColor;

        [JsonProperty("shadow_distance")]
        public double? ShadowDistance;

        [JsonProperty("shadow_point")]
        public ShadowPoint ShadowPoint;

        [JsonProperty("shadow_smoothing")]
        public double? ShadowSmoothing;

        [JsonProperty("shape_clip_x")]
        public bool? ShapeClipX;

        [JsonProperty("shape_clip_y")]
        public bool? ShapeClipY;

        [JsonProperty("source_from")]
        public string SourceFrom;

        [JsonProperty("style_name")]
        public string StyleName;

        [JsonProperty("sub_type")]
        public int? SubType;

        [JsonProperty("subtitle_keywords")]
        public object SubtitleKeywords;

        [JsonProperty("subtitle_template_original_fontsize")]
        public double? SubtitleTemplateOriginalFontsize;

        [JsonProperty("text_alpha")]
        public double? TextAlpha;

        [JsonProperty("text_color")]
        public string TextColor;

        [JsonProperty("text_curve")]
        public object TextCurve;

        [JsonProperty("text_preset_resource_id")]
        public string TextPresetResourceId;

        [JsonProperty("text_size")]
        public int? TextSize;

        [JsonProperty("text_to_audio_ids")]
        public List<object> TextToAudioIds;

        [JsonProperty("tts_auto_update")]
        public bool? TtsAutoUpdate;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("typesetting")]
        public int? Typesetting;

        [JsonProperty("underline")]
        public bool? Underline;

        [JsonProperty("underline_offset")]
        public double? UnderlineOffset;

        [JsonProperty("underline_width")]
        public double? UnderlineWidth;

        [JsonProperty("use_effect_default_color")]
        public bool? UseEffectDefaultColor;

        [JsonProperty("words")]
        public Words Words;
    }

    public class TimeRange
    {
        [JsonProperty("duration")]
        public int? Duration;

        [JsonProperty("start")]
        public int? Start;
    }

    public class Track
    {
        [JsonProperty("attribute")]
        public int? Attribute;

        [JsonProperty("flag")]
        public int? Flag;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("is_default_name")]
        public bool? IsDefaultName;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("segments")]
        public List<Segment> Segments;

        [JsonProperty("type")]
        public string Type;
    }

    public class Transform
    {
        [JsonProperty("x")]
        public double? X;

        [JsonProperty("y")]
        public double? Y;
    }

    public class UniformScale
    {
        [JsonProperty("on")]
        public bool? On;

        [JsonProperty("value")]
        public double? Value;
    }

    public class Video
    {
        [JsonProperty("aigc_type")]
        public string AigcType;

        [JsonProperty("audio_fade")]
        public object AudioFade;

        [JsonProperty("cartoon_path")]
        public string CartoonPath;

        [JsonProperty("category_id")]
        public string CategoryId;

        [JsonProperty("category_name")]
        public string CategoryName;

        [JsonProperty("check_flag")]
        public int? CheckFlag;

        [JsonProperty("crop")]
        public Crop Crop;

        [JsonProperty("crop_ratio")]
        public string CropRatio;

        [JsonProperty("crop_scale")]
        public double? CropScale;

        [JsonProperty("duration")]
        public int? Duration;

        [JsonProperty("extra_type_option")]
        public int? ExtraTypeOption;

        [JsonProperty("formula_id")]
        public string FormulaId;

        [JsonProperty("freeze")]
        public object Freeze;

        [JsonProperty("has_audio")]
        public bool? HasAudio;

        [JsonProperty("height")]
        public int? Height;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("intensifies_audio_path")]
        public string IntensifiesAudioPath;

        [JsonProperty("intensifies_path")]
        public string IntensifiesPath;

        [JsonProperty("is_ai_generate_content")]
        public bool? IsAiGenerateContent;

        [JsonProperty("is_copyright")]
        public bool? IsCopyright;

        [JsonProperty("is_text_edit_overdub")]
        public bool? IsTextEditOverdub;

        [JsonProperty("is_unified_beauty_mode")]
        public bool? IsUnifiedBeautyMode;

        [JsonProperty("local_id")]
        public string LocalId;

        [JsonProperty("local_material_id")]
        public string LocalMaterialId;

        [JsonProperty("material_id")]
        public string MaterialId;

        [JsonProperty("material_name")]
        public string MaterialName;

        [JsonProperty("material_url")]
        public string MaterialUrl;

        [JsonProperty("matting")]
        public Matting Matting;

        [JsonProperty("media_path")]
        public string MediaPath;

        [JsonProperty("object_locked")]
        public object ObjectLocked;

        [JsonProperty("origin_material_id")]
        public string OriginMaterialId;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("picture_from")]
        public string PictureFrom;

        [JsonProperty("picture_set_category_id")]
        public string PictureSetCategoryId;

        [JsonProperty("picture_set_category_name")]
        public string PictureSetCategoryName;

        [JsonProperty("request_id")]
        public string RequestId;

        [JsonProperty("reverse_intensifies_path")]
        public string ReverseIntensifiesPath;

        [JsonProperty("reverse_path")]
        public string ReversePath;

        [JsonProperty("smart_motion")]
        public object SmartMotion;

        [JsonProperty("source")]
        public int? Source;

        [JsonProperty("source_platform")]
        public int? SourcePlatform;

        [JsonProperty("stable")]
        public Stable Stable;

        [JsonProperty("team_id")]
        public string TeamId;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("video_algorithm")]
        public VideoAlgorithm VideoAlgorithm;

        [JsonProperty("width")]
        public int? Width;
    }

    public class VideoAlgorithm
    {
        [JsonProperty("algorithms")]
        public List<object> Algorithms;

        [JsonProperty("complement_frame_config")]
        public object ComplementFrameConfig;

        [JsonProperty("deflicker")]
        public object Deflicker;

        [JsonProperty("gameplay_configs")]
        public List<object> GameplayConfigs;

        [JsonProperty("motion_blur_config")]
        public object MotionBlurConfig;

        [JsonProperty("noise_reduction")]
        public object NoiseReduction;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("quality_enhance")]
        public object QualityEnhance;

        [JsonProperty("time_range")]
        public object TimeRange;
    }

    public class VocalSeparation
    {
        [JsonProperty("choice")]
        public int? Choice;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("production_path")]
        public string ProductionPath;

        [JsonProperty("time_range")]
        public object TimeRange;

        [JsonProperty("type")]
        public string Type;
    }

    public class Words
    {
        [JsonProperty("end_time")]
        public List<int?> EndTime;

        [JsonProperty("start_time")]
        public List<int?> StartTime;

        [JsonProperty("text")]
        public List<string> Text;
    }
}
