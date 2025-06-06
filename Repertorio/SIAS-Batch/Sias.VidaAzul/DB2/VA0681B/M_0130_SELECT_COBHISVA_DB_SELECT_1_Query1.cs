using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0681B
{
    public class M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1 : QueryBasis<M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_DEVOLUCAO
            INTO :COBHISVI-COD-DEVOLUCAO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO
            AND NUM_PARCELA = :COBHISVI-NUM-PARCELA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_DEVOLUCAO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.COBHISVI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.COBHISVI_NUM_PARCELA}'";

            return query;
        }
        public string COBHISVI_COD_DEVOLUCAO { get; set; }
        public string COBHISVI_NUM_CERTIFICADO { get; set; }
        public string COBHISVI_NUM_PARCELA { get; set; }

        public static M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1 Execute(M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1 m_0130_SELECT_COBHISVA_DB_SELECT_1_Query1)
        {
            var ths = m_0130_SELECT_COBHISVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0130_SELECT_COBHISVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBHISVI_COD_DEVOLUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}