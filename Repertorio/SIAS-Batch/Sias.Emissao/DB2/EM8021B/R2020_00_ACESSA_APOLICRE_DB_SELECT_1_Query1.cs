using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8021B
{
    public class R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1 : QueryBasis<R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROPRIET,
            TIPO_PESSOA,
            CGCCPF
            INTO :APOLICRE-PROPRIET,
            :APOLICRE-TIPO-PESSOA,
            :APOLICRE-CGCCPF
            FROM SEGUROS.APOLICE_CREDITO
            WHERE COD_SUREG = :SINCREIN-COD-SUREG
            AND COD_AGENCIA = :SINCREIN-COD-AGENCIA
            AND COD_OPERACAO = :SINCREIN-COD-OPERACAO
            AND NUM_CONTRATO = :SINCREIN-NUM-CONTRATO
            AND CONTRATO_DIGITO = :SINCREIN-CONTRATO-DIGITO
            AND SITUACAO IN ( '1' , 'A' , 'B' , 'S' , '3' )
            AND TIMESTAMP =
            (SELECT MAX(TIMESTAMP)
            FROM SEGUROS.APOLICE_CREDITO
            WHERE COD_SUREG = :SINCREIN-COD-SUREG
            AND COD_AGENCIA = :SINCREIN-COD-AGENCIA
            AND COD_OPERACAO = :SINCREIN-COD-OPERACAO
            AND NUM_CONTRATO = :SINCREIN-NUM-CONTRATO
            AND CONTRATO_DIGITO = :SINCREIN-CONTRATO-DIGITO
            AND SITUACAO IN ( '1' , 'A' , 'B' , 'S' , '3' ))
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROPRIET
							,
											TIPO_PESSOA
							,
											CGCCPF
											FROM SEGUROS.APOLICE_CREDITO
											WHERE COD_SUREG = '{this.SINCREIN_COD_SUREG}'
											AND COD_AGENCIA = '{this.SINCREIN_COD_AGENCIA}'
											AND COD_OPERACAO = '{this.SINCREIN_COD_OPERACAO}'
											AND NUM_CONTRATO = '{this.SINCREIN_NUM_CONTRATO}'
											AND CONTRATO_DIGITO = '{this.SINCREIN_CONTRATO_DIGITO}'
											AND SITUACAO IN ( '1' 
							, 'A' 
							, 'B' 
							, 'S' 
							, '3' )
											AND TIMESTAMP =
											(SELECT MAX(TIMESTAMP)
											FROM SEGUROS.APOLICE_CREDITO
											WHERE COD_SUREG = '{this.SINCREIN_COD_SUREG}'
											AND COD_AGENCIA = '{this.SINCREIN_COD_AGENCIA}'
											AND COD_OPERACAO = '{this.SINCREIN_COD_OPERACAO}'
											AND NUM_CONTRATO = '{this.SINCREIN_NUM_CONTRATO}'
											AND CONTRATO_DIGITO = '{this.SINCREIN_CONTRATO_DIGITO}'
											AND SITUACAO IN ( '1' 
							, 'A' 
							, 'B' 
							, 'S' 
							, '3' ))
											WITH UR";

            return query;
        }
        public string APOLICRE_PROPRIET { get; set; }
        public string APOLICRE_TIPO_PESSOA { get; set; }
        public string APOLICRE_CGCCPF { get; set; }
        public string SINCREIN_CONTRATO_DIGITO { get; set; }
        public string SINCREIN_COD_OPERACAO { get; set; }
        public string SINCREIN_NUM_CONTRATO { get; set; }
        public string SINCREIN_COD_AGENCIA { get; set; }
        public string SINCREIN_COD_SUREG { get; set; }

        public static R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1 Execute(R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1 r2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1)
        {
            var ths = r2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICRE_PROPRIET = result[i++].Value?.ToString();
            dta.APOLICRE_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.APOLICRE_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}