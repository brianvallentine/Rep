using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1 : QueryBasis<R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DTA_INI_FATURA
            INTO :V0COBP-DTINIVIG-PARC
            FROM SEGUROS.VG_VIGENCIA_FATURA
            WHERE NUM_APOLICE = :WHOST-NRAPOLICE
            AND COD_SUBGRUPO = 0
            AND SEQ_FATURAMENTO =
            (SELECT MAX(T1.SEQ_FATURAMENTO)
            FROM SEGUROS.VG_VIGENCIA_FATURA T1
            WHERE T1.NUM_APOLICE = :WHOST-NRAPOLICE
            AND T1.COD_SUBGRUPO = 0
            AND T1.IND_PROCESSAMENTO <> 'NP' )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DTA_INI_FATURA
											FROM SEGUROS.VG_VIGENCIA_FATURA
											WHERE NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND COD_SUBGRUPO = 0
											AND SEQ_FATURAMENTO =
											(SELECT MAX(T1.SEQ_FATURAMENTO)
											FROM SEGUROS.VG_VIGENCIA_FATURA T1
											WHERE T1.NUM_APOLICE = '{this.WHOST_NRAPOLICE}'
											AND T1.COD_SUBGRUPO = 0
											AND T1.IND_PROCESSAMENTO <> 'NP' )";

            return query;
        }
        public string V0COBP_DTINIVIG_PARC { get; set; }
        public string WHOST_NRAPOLICE { get; set; }

        public static R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1 Execute(R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1 r2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1)
        {
            var ths = r2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0COBP_DTINIVIG_PARC = result[i++].Value?.ToString();
            return dta;
        }

    }
}