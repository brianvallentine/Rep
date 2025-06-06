using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0630B
{
    public class M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            VALUES ( 'PF0630B' ,
            CURRENT DATE,
            'PF' ,
            'PF0613B' ,
            0,
            0,
            CURRENT DATE,
            CURRENT DATE,
            CURRENT DATE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            NULL,
            NULL,
            NULL,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.RELATORIOS VALUES ( 'PF0630B' , CURRENT DATE, 'PF' , 'PF0613B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, NULL, NULL, CURRENT TIMESTAMP)";

            return query;
        }

        public static void Execute(M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1 m_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = m_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}