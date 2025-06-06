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
    public class R0520_00_INSERT_GE398_DB_INSERT_1_Insert1 : QueryBasis<R0520_00_INSERT_GE398_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_ENDOS_PCT_PART_COBER
            (NUM_APOLICE
            ,NUM_ENDOSSO
            ,COD_RAMO_COBER
            ,COD_COBERTURA
            ,COD_COSSEGURADORA
            ,PCT_PARTIC_COBER
            ,PCT_COMCOS_COBER
            ,NOM_PROGRAMA
            ,DTH_CADASTRAMENTO)
            VALUES
            (:GE398-NUM-APOLICE
            ,:GE398-NUM-ENDOSSO
            ,:GE398-COD-RAMO-COBER
            ,:GE398-COD-COBERTURA
            ,:GE398-COD-COSSEGURADORA
            ,:GE398-PCT-PARTIC-COBER
            ,:GE398-PCT-COMCOS-COBER
            ,:GE398-NOM-PROGRAMA
            , CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_ENDOS_PCT_PART_COBER (NUM_APOLICE ,NUM_ENDOSSO ,COD_RAMO_COBER ,COD_COBERTURA ,COD_COSSEGURADORA ,PCT_PARTIC_COBER ,PCT_COMCOS_COBER ,NOM_PROGRAMA ,DTH_CADASTRAMENTO) VALUES ({FieldThreatment(this.GE398_NUM_APOLICE)} ,{FieldThreatment(this.GE398_NUM_ENDOSSO)} ,{FieldThreatment(this.GE398_COD_RAMO_COBER)} ,{FieldThreatment(this.GE398_COD_COBERTURA)} ,{FieldThreatment(this.GE398_COD_COSSEGURADORA)} ,{FieldThreatment(this.GE398_PCT_PARTIC_COBER)} ,{FieldThreatment(this.GE398_PCT_COMCOS_COBER)} ,{FieldThreatment(this.GE398_NOM_PROGRAMA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string GE398_NUM_APOLICE { get; set; }
        public string GE398_NUM_ENDOSSO { get; set; }
        public string GE398_COD_RAMO_COBER { get; set; }
        public string GE398_COD_COBERTURA { get; set; }
        public string GE398_COD_COSSEGURADORA { get; set; }
        public string GE398_PCT_PARTIC_COBER { get; set; }
        public string GE398_PCT_COMCOS_COBER { get; set; }
        public string GE398_NOM_PROGRAMA { get; set; }

        public static void Execute(R0520_00_INSERT_GE398_DB_INSERT_1_Insert1 r0520_00_INSERT_GE398_DB_INSERT_1_Insert1)
        {
            var ths = r0520_00_INSERT_GE398_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0520_00_INSERT_GE398_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}