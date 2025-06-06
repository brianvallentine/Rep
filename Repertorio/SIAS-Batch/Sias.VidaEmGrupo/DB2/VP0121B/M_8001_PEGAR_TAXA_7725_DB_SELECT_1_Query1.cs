using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1 : QueryBasis<M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT FAIXA,
            TAXAVG,
            TAXAAP
            INTO :MFAIXA,
            :MTXVG,
            :MTXAPMA
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = 1
            AND OPCAO_COBER = ' '
            AND COD_PLANO = :SIVPF-COD-PLANO
            AND DTINIVIG <= :PROPVA-DTQITBCO
            AND DTTERVIG >= :PROPVA-DTQITBCO
            AND IDADE_INICIAL <= 18
            AND IDADE_FINAL >= 18
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT FAIXA
							,
											TAXAVG
							,
											TAXAAP
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = 1
											AND OPCAO_COBER = ' '
											AND COD_PLANO = '{this.SIVPF_COD_PLANO}'
											AND DTINIVIG <= '{this.PROPVA_DTQITBCO}'
											AND DTTERVIG >= '{this.PROPVA_DTQITBCO}'
											AND IDADE_INICIAL <= 18
											AND IDADE_FINAL >= 18
											WITH UR";

            return query;
        }
        public string MFAIXA { get; set; }
        public string MTXVG { get; set; }
        public string MTXAPMA { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string SIVPF_COD_PLANO { get; set; }
        public string PROPVA_DTQITBCO { get; set; }

        public static M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1 Execute(M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1 m_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1)
        {
            var ths = m_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1();
            var i = 0;
            dta.MFAIXA = result[i++].Value?.ToString();
            dta.MTXVG = result[i++].Value?.ToString();
            dta.MTXAPMA = result[i++].Value?.ToString();
            return dta;
        }

    }
}