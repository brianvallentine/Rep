using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG5001B
{
    public class M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1 : QueryBasis<M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RELATORIOS
            VALUES (:R-CODUSU,
            :SISTEMA-DTMOVABE,
            'VG' ,
            'VG5001B' ,
            0,
            0,
            :SISTEMA-DTMOVABE,
            :SISTEMA-DTMOVABE,
            :SISTEMA-DTMOVABE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :R-NUM-APOLICE,
            0,
            :R-NRPARCEL,
            :SNUM-CERTIFICADO,
            0,
            :R-CODSUBES,
            :R-OPERACAO,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            :R-CORRECAO,
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
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ({FieldThreatment(this.R_CODUSU)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 'VG' , 'VG5001B' , 0, 0, {FieldThreatment(this.SISTEMA_DTMOVABE)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, {FieldThreatment(this.SISTEMA_DTMOVABE)}, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.R_NUM_APOLICE)}, 0, {FieldThreatment(this.R_NRPARCEL)}, {FieldThreatment(this.SNUM_CERTIFICADO)}, 0, {FieldThreatment(this.R_CODSUBES)}, {FieldThreatment(this.R_OPERACAO)}, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, {FieldThreatment(this.R_CORRECAO)}, '0' , ' ' , ' ' , NULL, NULL, NULL, CURRENT TIMESTAMP)";

            return query;
        }
        public string R_CODUSU { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string R_NUM_APOLICE { get; set; }
        public string R_NRPARCEL { get; set; }
        public string SNUM_CERTIFICADO { get; set; }
        public string R_CODSUBES { get; set; }
        public string R_OPERACAO { get; set; }
        public string R_CORRECAO { get; set; }

        public static void Execute(M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1 m_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1)
        {
            var ths = m_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_040_000_GRAVA_V0RELATORIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}