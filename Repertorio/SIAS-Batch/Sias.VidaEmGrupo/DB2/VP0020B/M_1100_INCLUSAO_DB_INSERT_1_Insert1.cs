using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0020B
{
    public class M_1100_INCLUSAO_DB_INSERT_1_Insert1 : QueryBasis<M_1100_INCLUSAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.V0FUNCIOCEF
            (COD_SUREG,
            COD_UNIDADE,
            DIG_UNIDADE,
            NOME_UNIDADE,
            NUM_MATRICULA,
            NOME_FUNCIONARIO,
            TIPO_VINCULO,
            NASCIMENTO,
            NUM_CPF,
            ENDERECO_CEF,
            CIDADE_CEF,
            SIGLA_UF,
            CEP,
            COD_AGENCIA,
            OPERACAO_CONTA,
            NUM_CONTA,
            DIG_CONTA,
            COD_RUBRICA,
            TIPO1,
            TIPO2,
            TIPO3,
            VALOR1,
            VALOR2,
            VALOR3,
            MES_VIGENCIA,
            COD_ANGARIADOR,
            CERTIF_PREF,
            STATUS731,
            PREMIO731,
            PCT_AUMENTO,
            UNIDADE_ORIGEM,
            CLASSE_ORIGEM,
            SITUACAO)
            VALUES
            (:SQL-SUREG,
            :SQL-UNIDADE,
            :SQL-DV,
            :SQL-NOME-UNID,
            :SQL-MATRICULA,
            :SQL-NOME-FUNC,
            'EMPREGADO CEF' ,
            :SQL-DATA-NASC,
            :SQL-CPF,
            :SQL-ENDERECO,
            :SQL-CIDADE,
            :SQL-UF,
            :SQL-CEP,
            :SQL-AGENCIA,
            :SQL-OPERACAO,
            :SQL-CONTA,
            :SQL-DV-CONTA,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            :SQL-UNID-ORIG:SQL-NOT-NULL,
            'A' ,
            '0' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FUNCIOCEF (COD_SUREG, COD_UNIDADE, DIG_UNIDADE, NOME_UNIDADE, NUM_MATRICULA, NOME_FUNCIONARIO, TIPO_VINCULO, NASCIMENTO, NUM_CPF, ENDERECO_CEF, CIDADE_CEF, SIGLA_UF, CEP, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA, COD_RUBRICA, TIPO1, TIPO2, TIPO3, VALOR1, VALOR2, VALOR3, MES_VIGENCIA, COD_ANGARIADOR, CERTIF_PREF, STATUS731, PREMIO731, PCT_AUMENTO, UNIDADE_ORIGEM, CLASSE_ORIGEM, SITUACAO) VALUES ({FieldThreatment(this.SQL_SUREG)}, {FieldThreatment(this.SQL_UNIDADE)}, {FieldThreatment(this.SQL_DV)}, {FieldThreatment(this.SQL_NOME_UNID)}, {FieldThreatment(this.SQL_MATRICULA)}, {FieldThreatment(this.SQL_NOME_FUNC)}, 'EMPREGADO CEF' , {FieldThreatment(this.SQL_DATA_NASC)}, {FieldThreatment(this.SQL_CPF)}, {FieldThreatment(this.SQL_ENDERECO)}, {FieldThreatment(this.SQL_CIDADE)}, {FieldThreatment(this.SQL_UF)}, {FieldThreatment(this.SQL_CEP)}, {FieldThreatment(this.SQL_AGENCIA)}, {FieldThreatment(this.SQL_OPERACAO)}, {FieldThreatment(this.SQL_CONTA)}, {FieldThreatment(this.SQL_DV_CONTA)}, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, NULL,  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : this.SQL_UNID_ORIG))}, 'A' , '0' )";

            return query;
        }
        public string SQL_SUREG { get; set; }
        public string SQL_UNIDADE { get; set; }
        public string SQL_DV { get; set; }
        public string SQL_NOME_UNID { get; set; }
        public string SQL_MATRICULA { get; set; }
        public string SQL_NOME_FUNC { get; set; }
        public string SQL_DATA_NASC { get; set; }
        public string SQL_CPF { get; set; }
        public string SQL_ENDERECO { get; set; }
        public string SQL_CIDADE { get; set; }
        public string SQL_UF { get; set; }
        public string SQL_CEP { get; set; }
        public string SQL_AGENCIA { get; set; }
        public string SQL_OPERACAO { get; set; }
        public string SQL_CONTA { get; set; }
        public string SQL_DV_CONTA { get; set; }
        public string SQL_UNID_ORIG { get; set; }
        public string SQL_NOT_NULL { get; set; }

        public static void Execute(M_1100_INCLUSAO_DB_INSERT_1_Insert1 m_1100_INCLUSAO_DB_INSERT_1_Insert1)
        {
            var ths = m_1100_INCLUSAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1100_INCLUSAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}