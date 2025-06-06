using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1 : QueryBasis<R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CLIENTES
            (COD_CLIENTE ,
            NOME_RAZAO ,
            TIPO_PESSOA ,
            CGCCPF ,
            SIT_REGISTRO ,
            DATA_NASCIMENTO ,
            COD_EMPRESA ,
            COD_PORTE_EMP ,
            COD_NATUREZA_ATIV ,
            COD_RAMO_ATIVIDADE ,
            COD_ATIVIDADE ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            COD_GRD_GRUPO_CBO ,
            COD_SUBGRUPO_CBO ,
            COD_GRUPO_BASE_CBO ,
            COD_SUBGR_BASE_CBO)
            VALUES (:CLIENTES-COD-CLIENTE,
            :CLIENTES-NOME-RAZAO,
            :CLIENTES-TIPO-PESSOA,
            :CLIENTES-CGCCPF,
            :CLIENTES-SIT-REGISTRO,
            :CLIENTES-DATA-NASCIMENTO,
            :CLIENTES-COD-EMPRESA,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            :CLIENTES-IDE-SEXO ,
            :CLIENTES-ESTADO-CIVIL ,
            NULL ,
            NULL ,
            NULL ,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO , COD_EMPRESA , COD_PORTE_EMP , COD_NATUREZA_ATIV , COD_RAMO_ATIVIDADE , COD_ATIVIDADE , IDE_SEXO , ESTADO_CIVIL , COD_GRD_GRUPO_CBO , COD_SUBGRUPO_CBO , COD_GRUPO_BASE_CBO , COD_SUBGR_BASE_CBO) VALUES ({FieldThreatment(this.CLIENTES_COD_CLIENTE)}, {FieldThreatment(this.CLIENTES_NOME_RAZAO)}, {FieldThreatment(this.CLIENTES_TIPO_PESSOA)}, {FieldThreatment(this.CLIENTES_CGCCPF)}, {FieldThreatment(this.CLIENTES_SIT_REGISTRO)}, {FieldThreatment(this.CLIENTES_DATA_NASCIMENTO)}, {FieldThreatment(this.CLIENTES_COD_EMPRESA)}, NULL , NULL , NULL , NULL , {FieldThreatment(this.CLIENTES_IDE_SEXO)} , {FieldThreatment(this.CLIENTES_ESTADO_CIVIL)} , NULL , NULL , NULL , NULL)";

            return query;
        }
        public string CLIENTES_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_SIT_REGISTRO { get; set; }
        public string CLIENTES_DATA_NASCIMENTO { get; set; }
        public string CLIENTES_COD_EMPRESA { get; set; }
        public string CLIENTES_IDE_SEXO { get; set; }
        public string CLIENTES_ESTADO_CIVIL { get; set; }

        public static void Execute(R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1 r4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1)
        {
            var ths = r4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4200_10_GRAVA_CLIENTES_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}