using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0061B
{
    public class R1800_LE_TAB_PLANO_DB_SELECT_1_Query1 : QueryBasis<R1800_LE_TAB_PLANO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLPREMIOTOT
            INTO :PLAVAVGA-VLPREMIOTOT
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :PROPSSVD-NUM-APOLICE
            AND CODSUBES = :PROPSSVD-COD-SUBGRUPO
            AND OPCAO_COBER = :PROPOFID-OPCAO-COBER
            AND DTINIVIG <= :PROPOFID-DTQITBCO
            AND DTTERVIG >= :PROPOFID-DTQITBCO
            AND IDADE_INICIAL <= :WS-IDADE
            AND IDADE_FINAL >= :WS-IDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLPREMIOTOT
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.PROPSSVD_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPSSVD_COD_SUBGRUPO}'
											AND OPCAO_COBER = '{this.PROPOFID_OPCAO_COBER}'
											AND DTINIVIG <= '{this.PROPOFID_DTQITBCO}'
											AND DTTERVIG >= '{this.PROPOFID_DTQITBCO}'
											AND IDADE_INICIAL <= '{this.WS_IDADE}'
											AND IDADE_FINAL >= '{this.WS_IDADE}'";

            return query;
        }
        public string PLAVAVGA_VLPREMIOTOT { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string WS_IDADE { get; set; }

        public static R1800_LE_TAB_PLANO_DB_SELECT_1_Query1 Execute(R1800_LE_TAB_PLANO_DB_SELECT_1_Query1 r1800_LE_TAB_PLANO_DB_SELECT_1_Query1)
        {
            var ths = r1800_LE_TAB_PLANO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_LE_TAB_PLANO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_LE_TAB_PLANO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLAVAVGA_VLPREMIOTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}