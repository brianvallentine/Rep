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
    public class M_0100_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<M_0100_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_ADESAO,
            COD_AGENCIA_OP,
            NUM_TERMO,
            NUM_MATRICULA_VEN,
            PERI_PAGAMENTO,
            NUM_APOLICE
            INTO :DTQITBCO,
            :AGENCIA,
            :NRTERMO,
            :NRMATRVEN,
            :PERI-PAGAMENTO,
            :NUM-APOLICE
            FROM SEGUROS.V0TERMOADESAO
            WHERE NUM_APOLICE = :V0COMI-NUM-APOLICE
            AND COD_SUBGRUPO = :CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_ADESAO
							,
											COD_AGENCIA_OP
							,
											NUM_TERMO
							,
											NUM_MATRICULA_VEN
							,
											PERI_PAGAMENTO
							,
											NUM_APOLICE
											FROM SEGUROS.V0TERMOADESAO
											WHERE NUM_APOLICE = '{this.V0COMI_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.CODSUBES}'";

            return query;
        }
        public string DTQITBCO { get; set; }
        public string AGENCIA { get; set; }
        public string NRTERMO { get; set; }
        public string NRMATRVEN { get; set; }
        public string PERI_PAGAMENTO { get; set; }
        public string NUM_APOLICE { get; set; }
        public string V0COMI_NUM_APOLICE { get; set; }
        public string CODSUBES { get; set; }

        public static M_0100_PROCESSA_DB_SELECT_1_Query1 Execute(M_0100_PROCESSA_DB_SELECT_1_Query1 m_0100_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = m_0100_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.DTQITBCO = result[i++].Value?.ToString();
            dta.AGENCIA = result[i++].Value?.ToString();
            dta.NRTERMO = result[i++].Value?.ToString();
            dta.NRMATRVEN = result[i++].Value?.ToString();
            dta.PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}