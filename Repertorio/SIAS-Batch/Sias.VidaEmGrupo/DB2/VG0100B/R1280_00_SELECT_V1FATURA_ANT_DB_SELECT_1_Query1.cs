using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1 : QueryBasis<R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO ,
            NUM_FATURA ,
            COD_OPERACAO ,
            TIPO_ENDOSSO ,
            NUM_ENDOSSO ,
            VAL_FATURA ,
            COD_FONTE ,
            NUM_RCAP ,
            VAL_RCAP ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            SIT_REGISTRO ,
            DATA_FATURA ,
            DATA_RCAP ,
            COD_EMPRESA ,
            DATA_VENCIMENTO
            INTO :V1FATR-NUM-APOL ,
            :V1FATR-COD-SUBG ,
            :V1FATR-NUM-FATUR ,
            :V1FATR-COD-OPER ,
            :V1FATR-TIPO-ENDOS ,
            :V1FATR-NUM-ENDOS ,
            :V1FATR-VAL-FATURA ,
            :V1FATR-COD-FONTE ,
            :V1FATR-NUM-RCAP ,
            :V1FATR-VAL-RCAP ,
            :V1FATR-DATA-INIVIG ,
            :V1FATR-DATA-TERVIG ,
            :V1FATR-SIT-REG ,
            :V1FATR-DATA-FATUR:V1FATR-DATA-FATU-I,
            :V1FATR-DATA-RCAP:V1FATR-DATA-RCAP-I,
            :V1FATR-COD-EMPRESA:VIND-COD-EMP,
            :V1FATR-DATA-VENC:V1FATR-DATA-VENC-I
            FROM SEGUROS.V1FATURAS
            WHERE NUM_APOLICE = :W1SOLF-NUM-APOL
            AND COD_SUBGRUPO = 0
            AND NUM_FATURA = :W2SOLF-NUM-FAT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											NUM_FATURA 
							,
											COD_OPERACAO 
							,
											TIPO_ENDOSSO 
							,
											NUM_ENDOSSO 
							,
											VAL_FATURA 
							,
											COD_FONTE 
							,
											NUM_RCAP 
							,
											VAL_RCAP 
							,
											DATA_INIVIGENCIA 
							,
											DATA_TERVIGENCIA 
							,
											SIT_REGISTRO 
							,
											DATA_FATURA 
							,
											DATA_RCAP 
							,
											COD_EMPRESA 
							,
											DATA_VENCIMENTO
											FROM SEGUROS.V1FATURAS
											WHERE NUM_APOLICE = '{this.W1SOLF_NUM_APOL}'
											AND COD_SUBGRUPO = 0
											AND NUM_FATURA = '{this.W2SOLF_NUM_FAT}'";

            return query;
        }
        public string V1FATR_NUM_APOL { get; set; }
        public string V1FATR_COD_SUBG { get; set; }
        public string V1FATR_NUM_FATUR { get; set; }
        public string V1FATR_COD_OPER { get; set; }
        public string V1FATR_TIPO_ENDOS { get; set; }
        public string V1FATR_NUM_ENDOS { get; set; }
        public string V1FATR_VAL_FATURA { get; set; }
        public string V1FATR_COD_FONTE { get; set; }
        public string V1FATR_NUM_RCAP { get; set; }
        public string V1FATR_VAL_RCAP { get; set; }
        public string V1FATR_DATA_INIVIG { get; set; }
        public string V1FATR_DATA_TERVIG { get; set; }
        public string V1FATR_SIT_REG { get; set; }
        public string V1FATR_DATA_FATUR { get; set; }
        public string V1FATR_DATA_FATU_I { get; set; }
        public string V1FATR_DATA_RCAP { get; set; }
        public string V1FATR_DATA_RCAP_I { get; set; }
        public string V1FATR_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V1FATR_DATA_VENC { get; set; }
        public string V1FATR_DATA_VENC_I { get; set; }
        public string W1SOLF_NUM_APOL { get; set; }
        public string W2SOLF_NUM_FAT { get; set; }

        public static R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1 Execute(R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1 r1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1)
        {
            var ths = r1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1FATR_NUM_APOL = result[i++].Value?.ToString();
            dta.V1FATR_COD_SUBG = result[i++].Value?.ToString();
            dta.V1FATR_NUM_FATUR = result[i++].Value?.ToString();
            dta.V1FATR_COD_OPER = result[i++].Value?.ToString();
            dta.V1FATR_TIPO_ENDOS = result[i++].Value?.ToString();
            dta.V1FATR_NUM_ENDOS = result[i++].Value?.ToString();
            dta.V1FATR_VAL_FATURA = result[i++].Value?.ToString();
            dta.V1FATR_COD_FONTE = result[i++].Value?.ToString();
            dta.V1FATR_NUM_RCAP = result[i++].Value?.ToString();
            dta.V1FATR_VAL_RCAP = result[i++].Value?.ToString();
            dta.V1FATR_DATA_INIVIG = result[i++].Value?.ToString();
            dta.V1FATR_DATA_TERVIG = result[i++].Value?.ToString();
            dta.V1FATR_SIT_REG = result[i++].Value?.ToString();
            dta.V1FATR_DATA_FATUR = result[i++].Value?.ToString();
            dta.V1FATR_DATA_FATU_I = string.IsNullOrWhiteSpace(dta.V1FATR_DATA_FATUR) ? "-1" : "0";
            dta.V1FATR_DATA_RCAP = result[i++].Value?.ToString();
            dta.V1FATR_DATA_RCAP_I = string.IsNullOrWhiteSpace(dta.V1FATR_DATA_RCAP) ? "-1" : "0";
            dta.V1FATR_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMP = string.IsNullOrWhiteSpace(dta.V1FATR_COD_EMPRESA) ? "-1" : "0";
            dta.V1FATR_DATA_VENC = result[i++].Value?.ToString();
            dta.V1FATR_DATA_VENC_I = string.IsNullOrWhiteSpace(dta.V1FATR_DATA_VENC) ? "-1" : "0";
            return dta;
        }

    }
}