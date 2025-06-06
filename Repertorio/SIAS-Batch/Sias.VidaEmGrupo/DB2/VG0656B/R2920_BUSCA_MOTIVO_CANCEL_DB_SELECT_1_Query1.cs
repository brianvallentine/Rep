using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0656B
{
    public class R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1 : QueryBasis<R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            A.COD_DEVOLUCAO,
            B.DESC_DEVOLUCAO
            INTO :COBHISVI-COD-DEVOLUCAO,
            :DEVOLVID-DESC-DEVOLUCAO
            FROM SEGUROS.COBER_HIST_VIDAZUL A,
            SEGUROS.DEVOLUCAO_VIDAZUL B
            WHERE A.COD_DEVOLUCAO = B.COD_DEVOLUCAO
            AND A.NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											A.COD_DEVOLUCAO
							,
											B.DESC_DEVOLUCAO
											FROM SEGUROS.COBER_HIST_VIDAZUL A
							,
											SEGUROS.DEVOLUCAO_VIDAZUL B
											WHERE A.COD_DEVOLUCAO = B.COD_DEVOLUCAO
											AND A.NUM_CERTIFICADO = '{this.COBHISVI_NUM_CERTIFICADO}'";

            return query;
        }
        public string COBHISVI_COD_DEVOLUCAO { get; set; }
        public string DEVOLVID_DESC_DEVOLUCAO { get; set; }
        public string COBHISVI_NUM_CERTIFICADO { get; set; }

        public static R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1 Execute(R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1 r2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1)
        {
            var ths = r2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBHISVI_COD_DEVOLUCAO = result[i++].Value?.ToString();
            dta.DEVOLVID_DESC_DEVOLUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}