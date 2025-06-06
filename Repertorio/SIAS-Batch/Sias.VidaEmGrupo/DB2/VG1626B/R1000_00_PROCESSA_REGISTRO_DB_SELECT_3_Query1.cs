using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_HISTORICO,
            DATE(TIMESTAMP),
            COD_USUARIO,
            DATA_INIVIGENCIA
            + :SUBGVGAP-PERI-FATURAMENTO MONTHS
            INTO :PROPOVA-OCORR-HISTORICO,
            :WHOST-DATA-HISCOBPR,
            :WHOST-COD-USUARIO,
            :WHOST-PROX-DATA-INIVIG
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_INIVIGENCIA <= :WHOST-DATA-VENCIMENTO
            AND DATA_TERVIGENCIA >= :WHOST-DATA-VENCIMENTO
            ORDER BY OCORR_HISTORICO DESC
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_HISTORICO
							,
											DATE(TIMESTAMP)
							,
											COD_USUARIO
							,
											DATA_INIVIGENCIA
											+ {this.SUBGVGAP_PERI_FATURAMENTO} MONTHS
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_INIVIGENCIA <= '{this.WHOST_DATA_VENCIMENTO}'
											AND DATA_TERVIGENCIA >= '{this.WHOST_DATA_VENCIMENTO}'
											ORDER BY OCORR_HISTORICO DESC
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string WHOST_DATA_HISCOBPR { get; set; }
        public string WHOST_COD_USUARIO { get; set; }
        public string WHOST_PROX_DATA_INIVIG { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string WHOST_DATA_VENCIMENTO { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1();
            var i = 0;
            dta.PROPOVA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.WHOST_DATA_HISCOBPR = result[i++].Value?.ToString();
            dta.WHOST_COD_USUARIO = result[i++].Value?.ToString();
            dta.WHOST_PROX_DATA_INIVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}