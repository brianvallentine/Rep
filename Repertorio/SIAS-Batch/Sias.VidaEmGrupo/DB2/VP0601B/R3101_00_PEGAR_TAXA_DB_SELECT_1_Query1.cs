using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1 : QueryBasis<R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TAXAVG
            INTO :WS-TAXAVG
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE
            NUM_APOLICE = :PROPSSVD-NUM-APOLICE
            AND CODSUBES = 1
            AND COD_PLANO = :PROPOFID-COD-PLANO
            AND OPCAO_COBER = ' '
            AND DTINIVIG <= :PROPOFID-DTQITBCO
            AND DTTERVIG >= :PROPOFID-DTQITBCO
            AND IDADE_INICIAL <= 18
            AND IDADE_FINAL >= 18
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXAVG
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE
											NUM_APOLICE = '{this.PROPSSVD_NUM_APOLICE}'
											AND CODSUBES = 1
											AND COD_PLANO = '{this.PROPOFID_COD_PLANO}'
											AND OPCAO_COBER = ' '
											AND DTINIVIG <= '{this.PROPOFID_DTQITBCO}'
											AND DTTERVIG >= '{this.PROPOFID_DTQITBCO}'
											AND IDADE_INICIAL <= 18
											AND IDADE_FINAL >= 18
											WITH UR";

            return query;
        }
        public string WS_TAXAVG { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }

        public static R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1 Execute(R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1 r3101_00_PEGAR_TAXA_DB_SELECT_1_Query1)
        {
            var ths = r3101_00_PEGAR_TAXA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_TAXAVG = result[i++].Value?.ToString();
            return dta;
        }

    }
}