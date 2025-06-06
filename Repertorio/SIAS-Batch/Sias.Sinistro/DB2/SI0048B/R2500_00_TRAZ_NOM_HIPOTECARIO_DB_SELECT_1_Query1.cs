using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0048B
{
    public class R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1 : QueryBasis<R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_SEGURADO,
            CGCCPF,
            DTH_NASCIMENTO,
            NUM_CONTRATO_CEF,
            MATR_AGENTE,
            COD_COBERTURA,
            TSTP_SITUACAO
            INTO :MOVSINIH-NOME-SEGURADO,
            :MOVSINIH-CGCCPF,
            :MOVSINIH-DTH-NASCIMENTO,
            :MOVSINIH-NUM-CONTRATO-CEF,
            :MOVSINIH-MATR-AGENTE,
            :MOVSINIH-COD-COBERTURA,
            :MOVSINIH-TSTP-SITUACAO
            FROM SEGUROS.MOVSINISTRO_HABIT B
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND TSTP_SITUACAO =
            (SELECT MAX(A.TSTP_SITUACAO)
            FROM SEGUROS.MOVSINISTRO_HABIT A
            WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_SEGURADO
							,
											CGCCPF
							,
											DTH_NASCIMENTO
							,
											NUM_CONTRATO_CEF
							,
											MATR_AGENTE
							,
											COD_COBERTURA
							,
											TSTP_SITUACAO
											FROM SEGUROS.MOVSINISTRO_HABIT B
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND TSTP_SITUACAO =
											(SELECT MAX(A.TSTP_SITUACAO)
											FROM SEGUROS.MOVSINISTRO_HABIT A
											WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO)
											WITH UR";

            return query;
        }
        public string MOVSINIH_NOME_SEGURADO { get; set; }
        public string MOVSINIH_CGCCPF { get; set; }
        public string MOVSINIH_DTH_NASCIMENTO { get; set; }
        public string MOVSINIH_NUM_CONTRATO_CEF { get; set; }
        public string MOVSINIH_MATR_AGENTE { get; set; }
        public string MOVSINIH_COD_COBERTURA { get; set; }
        public string MOVSINIH_TSTP_SITUACAO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1 Execute(R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1 r2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVSINIH_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.MOVSINIH_CGCCPF = result[i++].Value?.ToString();
            dta.MOVSINIH_DTH_NASCIMENTO = result[i++].Value?.ToString();
            dta.MOVSINIH_NUM_CONTRATO_CEF = result[i++].Value?.ToString();
            dta.MOVSINIH_MATR_AGENTE = result[i++].Value?.ToString();
            dta.MOVSINIH_COD_COBERTURA = result[i++].Value?.ToString();
            dta.MOVSINIH_TSTP_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}