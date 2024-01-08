using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Photon.Pun;
using UnityEngine;

[System.Serializable]
public class CommandGeneTarget : Command {
    public override string GetArg0() => "/geneTarget";
    public override void Execute(StringBuilder output, Kobold k, string[] args) {
        base.Execute(output, k, args);
        if (!CheatsProcessor.GetCheatsEnabled()) {
            throw new CheatsProcessor.CommandException("Cheats are not enabled, use `/cheats 1` to enable cheats.");
        }

        if (args.Length < 3) {
            throw new CheatsProcessor.CommandException("/geneTarget requires a gene name and a value");
        }
        if (!float.TryParse(args[2], out float amount)) {
                    throw new CheatsProcessor.CommandException("Usage: /geneTarget <Gene> <Value>");
        }
        Vector3 aimPosition = k.GetComponentInChildren<Animator>().GetBoneTransform(HumanBodyBones.Head).position;
        Vector3 aimDir = k.GetComponentInChildren<CharacterControllerAnimator>(true).eyeDir;
        foreach (RaycastHit hit in Physics.RaycastAll(aimPosition, aimDir, 5f)) {
            Kobold b = hit.collider.GetComponentInParent<Kobold>();
            if (b == null) continue;
            if (b == k) continue;
            k.photonView.RequestOwnership();
            KoboldGenes genes = b.GetGenes();
            switch(args[1])
            {
                case "maxEnergy":
                {
                    b.SetGenes(genes.With(maxEnergy: amount));
                    break;
                }
                case "baseSize":
                {
                    b.SetGenes(genes.With(baseSize: amount));
                    break;
                }
                case "fatSize":
                {
                    b.SetGenes(genes.With(fatSize: amount));
                    break;
                }
                case "ballSize":
                {
                    b.SetGenes(genes.With(ballSize: amount));
                    break;
                }
                case "dickSize":
                {
                    b.SetGenes(genes.With(dickSize: amount));
                    break;
                }
                case "breastSize":
                {
                    b.SetGenes(genes.With(breastSize: amount));
                    break;
                }
                case "bellySize":
                {
                    b.SetGenes(genes.With(bellySize: amount));
                    break;
                }
                case "dickThickness":
                {
                    b.SetGenes(genes.With(dickThickness: amount));
                    break;
                }
                default: throw new CheatsProcessor.CommandException("Usage: /gene <Gene> <Value>");

            }
            return;
        }
        throw new CheatsProcessor.CommandException("Need to be facing the kobold to use");
        
    }
}
