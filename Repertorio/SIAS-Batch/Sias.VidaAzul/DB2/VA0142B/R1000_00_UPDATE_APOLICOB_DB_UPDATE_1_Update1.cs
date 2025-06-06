using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0142B
{
    public class R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 : QueryBasis<R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.APOLICE_COBERTURAS
				SET RAMO_COBERTURA =  '{this.APOLICOB_RAMO_COBERTURA}'
				,MODALI_COBERTURA =  '{this.APOLICOB_MODALI_COBERTURA}'
				,COD_COBERTURA =  '{this.APOLICOB_COD_COBERTURA}'
				,IMP_SEGURADA_IX =  '{this.APOLICOB_IMP_SEGURADA_IX}'
				,PRM_TARIFARIO_IX =  '{this.APOLICOB_PRM_TARIFARIO_IX}'
				,IMP_SEGURADA_VAR =  '{this.APOLICOB_IMP_SEGURADA_VAR}'
				,PRM_TARIFARIO_VAR =  '{this.APOLICOB_PRM_TARIFARIO_VAR}'
				,PCT_COBERTURA =  '{this.APOLICOB_PCT_COBERTURA}'
				,COD_EMPRESA =  {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : $"{this.APOLICOB_COD_EMPRESA}"))}
				,SIT_REGISTRO =  {FieldThreatment((this.VIND_NULL02?.ToInt() == -1 ? null : $"{this.APOLICOB_SIT_REGISTRO}"))}
				WHERE  NUM_APOLICE =  '{this.APOLICOB_NUM_APOLICE}'
				AND NUM_ENDOSSO =  '{this.APOLICOB_NUM_ENDOSSO}'
				AND NUM_ITEM =  '{this.APOLICOB_NUM_ITEM}'
				AND OCORR_HISTORICO =  '{this.APOLICOB_OCORR_HISTORICO}'
				AND RAMO_COBERTURA =  '{this.APOLICOB_RAMO_COBERTURA}'
				AND COD_COBERTURA =  '{this.APOLICOB_COD_COBERTURA}'";

            return query;
        }
        public string APOLICOB_SIT_REGISTRO { get; set; }
        public string VIND_NULL02 { get; set; }
        public string APOLICOB_COD_EMPRESA { get; set; }
        public string VIND_NULL01 { get; set; }
        public string APOLICOB_PRM_TARIFARIO_VAR { get; set; }
        public string APOLICOB_MODALI_COBERTURA { get; set; }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string APOLICOB_IMP_SEGURADA_VAR { get; set; }
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string APOLICOB_RAMO_COBERTURA { get; set; }
        public string APOLICOB_COD_COBERTURA { get; set; }
        public string APOLICOB_PCT_COBERTURA { get; set; }
        public string APOLICOB_OCORR_HISTORICO { get; set; }
        public string APOLICOB_NUM_APOLICE { get; set; }
        public string APOLICOB_NUM_ENDOSSO { get; set; }
        public string APOLICOB_NUM_ITEM { get; set; }

        public static void Execute(R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 r1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1)
        {
            var ths = r1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}