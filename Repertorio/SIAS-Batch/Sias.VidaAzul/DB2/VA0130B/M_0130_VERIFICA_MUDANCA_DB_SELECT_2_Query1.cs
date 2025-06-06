using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1 : QueryBasis<M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IDADE_FINAL ,
            TAXAAP ,
            FAIXA ,
            PCT_FAIXA_ETARIA
            INTO :PLAVAVGA-IDADE-FINAL,
            :PLAVAVGA-TAXAAP ,
            :PLAVAVGA-FAIXA ,
            :PLAVAVGA-PCT-FAIXA-ETARIA
            FROM SEGUROS.PLANOS_VA_VGAP
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND CODSUBES = :PROPVA-CODSUBES
            AND IMPMORNATU = :COBERP-IMPMORNATU-ANT
            AND DTINIVIG <= :SISTEMA-DTMOVABE
            AND DTTERVIG >= :SISTEMA-DTMOVABE
            AND IDADE_INICIAL <= :WHOST-IDADE
            AND IDADE_FINAL >= :WHOST-IDADE
            AND PERIPGTO = :OPCAOP-PERIPGTO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT IDADE_FINAL 
							,
											TAXAAP 
							,
											FAIXA 
							,
											PCT_FAIXA_ETARIA
											FROM SEGUROS.PLANOS_VA_VGAP
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND CODSUBES = '{this.PROPVA_CODSUBES}'
											AND IMPMORNATU = '{this.COBERP_IMPMORNATU_ANT}'
											AND DTINIVIG <= '{this.SISTEMA_DTMOVABE}'
											AND DTTERVIG >= '{this.SISTEMA_DTMOVABE}'
											AND IDADE_INICIAL <= '{this.WHOST_IDADE}'
											AND IDADE_FINAL >= '{this.WHOST_IDADE}'
											AND PERIPGTO = '{this.OPCAOP_PERIPGTO}'
											WITH UR";

            return query;
        }
        public string PLAVAVGA_IDADE_FINAL { get; set; }
        public string PLAVAVGA_TAXAAP { get; set; }
        public string PLAVAVGA_FAIXA { get; set; }
        public string PLAVAVGA_PCT_FAIXA_ETARIA { get; set; }
        public string COBERP_IMPMORNATU_ANT { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string OPCAOP_PERIPGTO { get; set; }
        public string WHOST_IDADE { get; set; }

        public static M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1 Execute(M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1 m_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1)
        {
            var ths = m_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0130_VERIFICA_MUDANCA_DB_SELECT_2_Query1();
            var i = 0;
            dta.PLAVAVGA_IDADE_FINAL = result[i++].Value?.ToString();
            dta.PLAVAVGA_TAXAAP = result[i++].Value?.ToString();
            dta.PLAVAVGA_FAIXA = result[i++].Value?.ToString();
            dta.PLAVAVGA_PCT_FAIXA_ETARIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}