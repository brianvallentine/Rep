using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM1139B
{
    public class R0510_00_INSERT_GE397_DB_INSERT_1_Insert1 : QueryBasis<R0510_00_INSERT_GE397_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_ENDOS_COSSEG_COBER
            (NUM_APOLICE
            ,NUM_ENDOSSO
            ,COD_RAMO_COBER
            ,COD_COBERTURA
            ,VLR_IMP_SEGUR_VAR
            ,VLR_PREMIO_TARIF_VAR
            ,NOM_PROGRAMA
            ,DTH_CADASTRAMENTO)
            VALUES
            (:GE397-NUM-APOLICE
            ,:GE397-NUM-ENDOSSO
            ,:GE397-COD-RAMO-COBER
            ,:GE397-COD-COBERTURA
            ,:GE397-VLR-IMP-SEGUR-VAR
            ,:GE397-VLR-PREMIO-TARIF-VAR
            ,:GE397-NOM-PROGRAMA
            , CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_ENDOS_COSSEG_COBER (NUM_APOLICE ,NUM_ENDOSSO ,COD_RAMO_COBER ,COD_COBERTURA ,VLR_IMP_SEGUR_VAR ,VLR_PREMIO_TARIF_VAR ,NOM_PROGRAMA ,DTH_CADASTRAMENTO) VALUES ({FieldThreatment(this.GE397_NUM_APOLICE)} ,{FieldThreatment(this.GE397_NUM_ENDOSSO)} ,{FieldThreatment(this.GE397_COD_RAMO_COBER)} ,{FieldThreatment(this.GE397_COD_COBERTURA)} ,{FieldThreatment(this.GE397_VLR_IMP_SEGUR_VAR)} ,{FieldThreatment(this.GE397_VLR_PREMIO_TARIF_VAR)} ,{FieldThreatment(this.GE397_NOM_PROGRAMA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string GE397_NUM_APOLICE { get; set; }
        public string GE397_NUM_ENDOSSO { get; set; }
        public string GE397_COD_RAMO_COBER { get; set; }
        public string GE397_COD_COBERTURA { get; set; }
        public string GE397_VLR_IMP_SEGUR_VAR { get; set; }
        public string GE397_VLR_PREMIO_TARIF_VAR { get; set; }
        public string GE397_NOM_PROGRAMA { get; set; }

        public static void Execute(R0510_00_INSERT_GE397_DB_INSERT_1_Insert1 r0510_00_INSERT_GE397_DB_INSERT_1_Insert1)
        {
            var ths = r0510_00_INSERT_GE397_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0510_00_INSERT_GE397_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}