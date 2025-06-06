using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 : QueryBasis<R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE (MAX(IMPMORNATU),0)
            INTO :WHOST-IMPMORNATU-MAX
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE =
            :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE
            AND CODSUBES =
            :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO
            AND COD_PLANO =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO
            AND OPCAO_COBER =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER
            AND DTINIVIG <=
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO
            AND DTTERVIG >=
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO
            AND IDADE_INICIAL <= :WHOST-IDADE
            AND IDADE_FINAL >= :WHOST-IDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE (MAX(IMPMORNATU)
							,0)
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE =
											'{this.PROPSSVD_NUM_APOLICE}'
											AND CODSUBES =
											'{this.PROPSSVD_COD_SUBGRUPO}'
											AND COD_PLANO =
											'{this.PROPOFID_COD_PLANO}'
											AND OPCAO_COBER =
											'{this.PROPOFID_OPCAO_COBER}'
											AND DTINIVIG <=
											'{this.PROPOFID_DTQITBCO}'
											AND DTTERVIG >=
											'{this.PROPOFID_DTQITBCO}'
											AND IDADE_INICIAL <= '{this.WHOST_IDADE}'
											AND IDADE_FINAL >= '{this.WHOST_IDADE}'";

            return query;
        }
        public string WHOST_IMPMORNATU_MAX { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string WHOST_IDADE { get; set; }

        public static R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 Execute(R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 r1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1)
        {
            var ths = r1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_IMPMORNATU_MAX = result[i++].Value?.ToString();
            return dta;
        }

    }
}