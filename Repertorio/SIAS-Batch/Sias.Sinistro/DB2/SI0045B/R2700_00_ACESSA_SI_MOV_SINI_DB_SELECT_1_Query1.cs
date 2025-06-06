using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1 : QueryBasis<R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_ESTIPULANTE,
            COD_PRODUTO,
            NUM_CONTR_ESTIP,
            NOME_SEGURADO,
            VALUE(COD_ASHAB,0),
            NATUREZA_SINISTRO,
            VALUE(RAMO_EMISSOR,0),
            VALUE(COD_CAUSA,0),
            DATA_COMUNICADO,
            COD_GIAFI
            INTO :SIMOVSIN-COD-ESTIPULANTE,
            :SIMOVSIN-COD-PRODUTO,
            :SIMOVSIN-NUM-CONTR-ESTIP,
            :SIMOVSIN-NOME-SEGURADO,
            :SIMOVSIN-COD-ASHAB,
            :SIMOVSIN-NATUREZA-SINISTRO,
            :SIMOVSIN-RAMO-EMISSOR,
            :SIMOVSIN-COD-CAUSA,
            :SIMOVSIN-DATA-COMUNICADO,
            :SIMOVSIN-COD-GIAFI
            FROM SEGUROS.SI_MOVIMENTO_SINI
            WHERE COD_FONTE = :SISINACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_ESTIPULANTE
							,
											COD_PRODUTO
							,
											NUM_CONTR_ESTIP
							,
											NOME_SEGURADO
							,
											VALUE(COD_ASHAB
							,0)
							,
											NATUREZA_SINISTRO
							,
											VALUE(RAMO_EMISSOR
							,0)
							,
											VALUE(COD_CAUSA
							,0)
							,
											DATA_COMUNICADO
							,
											COD_GIAFI
											FROM SEGUROS.SI_MOVIMENTO_SINI
											WHERE COD_FONTE = '{this.SISINACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SISINACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SISINACO_DAC_PROTOCOLO_SINI}'
											WITH UR";

            return query;
        }
        public string SIMOVSIN_COD_ESTIPULANTE { get; set; }
        public string SIMOVSIN_COD_PRODUTO { get; set; }
        public string SIMOVSIN_NUM_CONTR_ESTIP { get; set; }
        public string SIMOVSIN_NOME_SEGURADO { get; set; }
        public string SIMOVSIN_COD_ASHAB { get; set; }
        public string SIMOVSIN_NATUREZA_SINISTRO { get; set; }
        public string SIMOVSIN_RAMO_EMISSOR { get; set; }
        public string SIMOVSIN_COD_CAUSA { get; set; }
        public string SIMOVSIN_DATA_COMUNICADO { get; set; }
        public string SIMOVSIN_COD_GIAFI { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_COD_FONTE { get; set; }

        public static R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1 Execute(R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1 r2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1)
        {
            var ths = r2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_00_ACESSA_SI_MOV_SINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIMOVSIN_COD_ESTIPULANTE = result[i++].Value?.ToString();
            dta.SIMOVSIN_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SIMOVSIN_NUM_CONTR_ESTIP = result[i++].Value?.ToString();
            dta.SIMOVSIN_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.SIMOVSIN_COD_ASHAB = result[i++].Value?.ToString();
            dta.SIMOVSIN_NATUREZA_SINISTRO = result[i++].Value?.ToString();
            dta.SIMOVSIN_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.SIMOVSIN_COD_CAUSA = result[i++].Value?.ToString();
            dta.SIMOVSIN_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SIMOVSIN_COD_GIAFI = result[i++].Value?.ToString();
            return dta;
        }

    }
}