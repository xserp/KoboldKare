using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Photon.Pun;
using UnityEngine;

[System.Serializable]
public class CommandGene : Command {
    public override string GetArg0() => "/gene";
    public override void Execute(StringBuilder output, Kobold k, string[] args) {
        base.Execute(output, k, args);
        if (!CheatsProcessor.GetCheatsEnabled()) {
            throw new CheatsProcessor.CommandException("Cheats are not enabled, use `/cheats 1` to enable cheats.");
        }

        if (args.Length < 3) {
            throw new CheatsProcessor.CommandException("/gene requires a gene name and a value");
        }
        if (!float.TryParse(args[2], out float amount)) {
                    throw new CheatsProcessor.CommandException("Usage: /gene <Gene> <Value>");
        }
        k.photonView.RequestOwnership();
        KoboldGenes genes = k.GetGenes();
        switch(args[1])
        {
            case "maxEnergy":
            {
                k.SetGenes(genes.With(maxEnergy: amount));
                break;
            }
            case "baseSize":
            {
                k.SetGenes(genes.With(baseSize: amount));
                break;
            }
            case "fatSize":
            {
                k.SetGenes(genes.With(fatSize: amount));
                break;
            }
            case "ballSize":
            {
                k.SetGenes(genes.With(ballSize: amount));
                break;
            }
            case "dickSize":
            {
                k.SetGenes(genes.With(dickSize: amount));
                break;
            }
            case "breastSize":
            {
                k.SetGenes(genes.With(breastSize: amount));
                break;
            }
            case "bellySize":
            {
                k.SetGenes(genes.With(bellySize: amount));
                break;
            }
            case "dickThickness":
            {
                k.SetGenes(genes.With(dickThickness: amount));
                break;
            }
            default: throw new CheatsProcessor.CommandException("Usage: /gene <Gene> <Value>");

        }
        
    }
}
