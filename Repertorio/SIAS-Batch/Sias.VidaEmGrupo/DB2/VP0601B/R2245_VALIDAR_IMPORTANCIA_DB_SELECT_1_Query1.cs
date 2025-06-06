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
    public class R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1 : QueryBasis<R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FAIXA_SAL_FIM, TAXAVG
            INTO :DCLPLANOS-VA-VGAP.FAIXA-SAL-FIM,
            :DCLPLANOS-VA-VGAP.TAXAVG
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE
            NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE
            AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO
            AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO
            AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER
            AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO
            AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO
            AND IDADE_INICIAL <= :WHOST-IDADE-2
            AND IDADE_FINAL >= :WHOST-IDADE-2
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT FAIXA_SAL_FIM
							, TAXAVG
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE
											NUM_APOLICE = '{this.PROPSSVD_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPSSVD_COD_SUBGRUPO}'
											AND COD_PLANO = '{this.PROPOFID_COD_PLANO}'
											AND OPCAO_COBER = '{this.PROPOFID_OPCAO_COBER}'
											AND DTINIVIG <= '{this.PROPOFID_DTQITBCO}'
											AND DTTERVIG >= '{this.PROPOFID_DTQITBCO}'
											AND IDADE_INICIAL <= '{this.WHOST_IDADE_2}'
											AND IDADE_FINAL >= '{this.WHOST_IDADE_2}'
											WITH UR";

            return query;
        }
        public string FAIXA_SAL_FIM { get; set; }
        public string TAXAVG { get; set; }
        public string PROPSSVD_COD_SUBGRUPO { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string PROPSSVD_NUM_APOLICE { get; set; }
        public string PROPOFID_COD_PLANO { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string WHOST_IDADE_2 { get; set; }

        public static R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1 Execute(R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1 r2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1)
        {
            var ths = r2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.FAIXA_SAL_FIM = result[i++].Value?.ToString();
            dta.TAXAVG = result[i++].Value?.ToString();
            return dta;
        }

    }
}