using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0123B
{
    public class R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OPCAO_COBERTURA ,
            VLPREMIO ,
            PRMVG ,
            PRMAP ,
            DATA_INIVIGENCIA,
            DATA_INIVIGENCIA - 1 DAY
            INTO :HISCOBPR-OPCAO-COBERTURA ,
            :HISCOBPR-VLPREMIO ,
            :HISCOBPR-PRMVG ,
            :HISCOBPR-PRMAP ,
            :HISCOBPR-DATA-INIVIGENCIA,
            :HISCOBPR-DATA-INIVIG-1
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OPCAO_COBERTURA 
							,
											VLPREMIO 
							,
											PRMVG 
							,
											PRMAP 
							,
											DATA_INIVIGENCIA
							,
											DATA_INIVIGENCIA - 1 DAY
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string HISCOBPR_OPCAO_COBERTURA { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_PRMVG { get; set; }
        public string HISCOBPR_PRMAP { get; set; }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_DATA_INIVIG_1 { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMVG = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMAP = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_INIVIG_1 = result[i++].Value?.ToString();
            return dta;
        }

    }
}