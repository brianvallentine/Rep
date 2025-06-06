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
    public class M_8000_INTEGRA_VG_DB_SELECT_4_Query1 : QueryBasis<M_8000_INTEGRA_VG_DB_SELECT_4_Query1>
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
            AND CODSUBES = :PROPVA-CODSUBES
            AND OPCAO_COBER = :PROPVA-OPCAO-COBER
            AND COD_PLANO = :SIVPF-COD-PLANO
            AND DTINIVIG <= :WHOST-DTINIVIG
            AND DTTERVIG >= :WHOST-DTINIVIG
            AND IDADE_INICIAL <= :PROPVA-IDADE
            AND IDADE_FINAL >= :PROPVA-IDADE
            AND PERIPGTO = :OPCAOP-PERIPGTO
            AND (IMPMORNATU = :COBERP-IMPMORNATU
            OR IMPMORNATU = 0)
            WITH UR
            END-EXEC
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
											AND CODSUBES = '{this.PROPVA_CODSUBES}'
											AND OPCAO_COBER = '{this.PROPVA_OPCAO_COBER}'
											AND COD_PLANO = '{this.SIVPF_COD_PLANO}'
											AND DTINIVIG <= '{this.WHOST_DTINIVIG}'
											AND DTTERVIG >= '{this.WHOST_DTINIVIG}'
											AND IDADE_INICIAL <= '{this.PROPVA_IDADE}'
											AND IDADE_FINAL >= '{this.PROPVA_IDADE}'
											AND PERIPGTO = '{this.OPCAOP_PERIPGTO}'
											AND (IMPMORNATU = '{this.COBERP_IMPMORNATU}'
											OR IMPMORNATU = 0)
											WITH UR";

            return query;
        }
        public string MFAIXA { get; set; }
        public string MTXVG { get; set; }
        public string MTXAPMA { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string COBERP_IMPMORNATU { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string SIVPF_COD_PLANO { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string WHOST_DTINIVIG { get; set; }
        public string PROPVA_IDADE { get; set; }

        public static M_8000_INTEGRA_VG_DB_SELECT_4_Query1 Execute(M_8000_INTEGRA_VG_DB_SELECT_4_Query1 m_8000_INTEGRA_VG_DB_SELECT_4_Query1)
        {
            var ths = m_8000_INTEGRA_VG_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_8000_INTEGRA_VG_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_8000_INTEGRA_VG_DB_SELECT_4_Query1();
            var i = 0;
            dta.MFAIXA = result[i++].Value?.ToString();
            dta.MTXVG = result[i++].Value?.ToString();
            dta.MTXAPMA = result[i++].Value?.ToString();
            return dta;
        }

    }
}