using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0505B
{
    public class M_0100_PROCESSA_DB_SELECT_2_Query1 : QueryBasis<M_0100_PROCESSA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO
            INTO :COD-PRODUTO
            FROM SEGUROS.VG_PRODUTO_SIAS
            WHERE NUM_APOLICE =
            :NUM-APOLICE
            AND NUM_PERIODO_PAG =
            :PERI-PAGAMENTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
											FROM SEGUROS.VG_PRODUTO_SIAS
											WHERE NUM_APOLICE =
											'{this.NUM_APOLICE}'
											AND NUM_PERIODO_PAG =
											'{this.PERI_PAGAMENTO}'";

            return query;
        }
        public string COD_PRODUTO { get; set; }
        public string PERI_PAGAMENTO { get; set; }
        public string NUM_APOLICE { get; set; }

        public static M_0100_PROCESSA_DB_SELECT_2_Query1 Execute(M_0100_PROCESSA_DB_SELECT_2_Query1 m_0100_PROCESSA_DB_SELECT_2_Query1)
        {
            var ths = m_0100_PROCESSA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_DB_SELECT_2_Query1();
            var i = 0;
            dta.COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}