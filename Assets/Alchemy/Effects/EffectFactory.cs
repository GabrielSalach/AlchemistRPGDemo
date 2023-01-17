public static class EffectFactory {
    public static Effect GetEffect(EffectData data) {
        Effect effect = null;
        
        switch(data.effectName) {
            case "Speed":
                effect = new SpeedEffect(3, data);
                break;
            
            default:
                break;
        }
        return effect;
    }
}