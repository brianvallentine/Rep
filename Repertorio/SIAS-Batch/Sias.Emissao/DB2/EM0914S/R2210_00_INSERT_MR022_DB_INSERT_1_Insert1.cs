using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0914S
{
    public class R2210_00_INSERT_MR022_DB_INSERT_1_Insert1 : QueryBasis<R2210_00_INSERT_MR022_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.MR_APOL_ITEM_EMPR
            (NUM_APOLICE,
            NUM_ENDOSSO,
            NUM_ITEM,
            NUM_SUB_ITEM,
            COD_RUBRICA,
            COD_SUB_RUBRICA,
            PCT_DESC_COBERTURA,
            PCT_DESC_CORRETOR,
            PCT_BONUS_RENOVCAO,
            DTH_CADASTRAMENTO ,
            COD_BENEFICIARIO ,
            DES_CLAUSULA_BENEF)
            VALUES (:MR022-NUM-APOLICE,
            :MR022-NUM-ENDOSSO,
            :MR022-NUM-ITEM,
            :MR022-NUM-SUB-ITEM,
            :MR022-COD-RUBRICA,
            :MR022-COD-SUB-RUBRICA,
            :MR022-PCT-DESC-COBERTURA,
            :MR022-PCT-DESC-CORRETOR,
            :MR022-PCT-BONUS-RENOVCAO,
            CURRENT TIMESTAMP ,
            :MR022-COD-BENEFICIARIO :WSNULL-COD-EMP ,
            :MR022-DES-CLAUSULA-BENEF :WSNULL-DES-EMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MR_APOL_ITEM_EMPR (NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, NUM_SUB_ITEM, COD_RUBRICA, COD_SUB_RUBRICA, PCT_DESC_COBERTURA, PCT_DESC_CORRETOR, PCT_BONUS_RENOVCAO, DTH_CADASTRAMENTO , COD_BENEFICIARIO , DES_CLAUSULA_BENEF) VALUES ({FieldThreatment(this.MR022_NUM_APOLICE)}, {FieldThreatment(this.MR022_NUM_ENDOSSO)}, {FieldThreatment(this.MR022_NUM_ITEM)}, {FieldThreatment(this.MR022_NUM_SUB_ITEM)}, {FieldThreatment(this.MR022_COD_RUBRICA)}, {FieldThreatment(this.MR022_COD_SUB_RUBRICA)}, {FieldThreatment(this.MR022_PCT_DESC_COBERTURA)}, {FieldThreatment(this.MR022_PCT_DESC_CORRETOR)}, {FieldThreatment(this.MR022_PCT_BONUS_RENOVCAO)}, CURRENT TIMESTAMP ,  {FieldThreatment((this.WSNULL_COD_EMP?.ToInt() == -1 ? null : this.MR022_COD_BENEFICIARIO))} ,  {FieldThreatment((this.WSNULL_DES_EMP?.ToInt() == -1 ? null : this.MR022_DES_CLAUSULA_BENEF))})";

            return query;
        }
        public string MR022_NUM_APOLICE { get; set; }
        public string MR022_NUM_ENDOSSO { get; set; }
        public string MR022_NUM_ITEM { get; set; }
        public string MR022_NUM_SUB_ITEM { get; set; }
        public string MR022_COD_RUBRICA { get; set; }
        public string MR022_COD_SUB_RUBRICA { get; set; }
        public string MR022_PCT_DESC_COBERTURA { get; set; }
        public string MR022_PCT_DESC_CORRETOR { get; set; }
        public string MR022_PCT_BONUS_RENOVCAO { get; set; }
        public string MR022_COD_BENEFICIARIO { get; set; }
        public string WSNULL_COD_EMP { get; set; }
        public string MR022_DES_CLAUSULA_BENEF { get; set; }
        public string WSNULL_DES_EMP { get; set; }

        public static void Execute(R2210_00_INSERT_MR022_DB_INSERT_1_Insert1 r2210_00_INSERT_MR022_DB_INSERT_1_Insert1)
        {
            var ths = r2210_00_INSERT_MR022_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2210_00_INSERT_MR022_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}