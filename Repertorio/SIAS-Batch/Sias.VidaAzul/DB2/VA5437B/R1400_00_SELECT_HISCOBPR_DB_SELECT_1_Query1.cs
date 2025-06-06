using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA,
            COD_OPERACAO,
            OPCAO_COBERTURA,
            IMP_MORNATU,
            IMPSEGCDG,
            VLPREMIO,
            VAL_CUSTO_CAPITALI
            INTO :HISCOBPR-DATA-INIVIGENCIA,
            :HISCOBPR-COD-OPERACAO,
            :HISCOBPR-OPCAO-COBERTURA,
            :HISCOBPR-IMP-MORNATU,
            :HISCOBPR-IMPSEGCDG,
            :HISCOBPR-VLPREMIO,
            :HISCOBPR-VAL-CUSTO-CAPITALI
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
							,
											COD_OPERACAO
							,
											OPCAO_COBERTURA
							,
											IMP_MORNATU
							,
											IMPSEGCDG
							,
											VLPREMIO
							,
											VAL_CUSTO_CAPITALI
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											WITH UR";

            return query;
        }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_COD_OPERACAO { get; set; }
        public string HISCOBPR_OPCAO_COBERTURA { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPSEGCDG { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_VAL_CUSTO_CAPITALI { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_COD_OPERACAO = result[i++].Value?.ToString();
            dta.HISCOBPR_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPSEGCDG = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            dta.HISCOBPR_VAL_CUSTO_CAPITALI = result[i++].Value?.ToString();
            return dta;
        }

    }
}